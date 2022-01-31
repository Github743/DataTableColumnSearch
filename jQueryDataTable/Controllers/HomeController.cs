using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Globalization;
using jQueryDataTable.Models;
using System.Collections.Generic;

namespace jQueryDataTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadData()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            string search = Request.Form.GetValues("search[value]")[0];

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (BMA_DEVEntities context = new BMA_DEVEntities())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = from vd in context.VesselDetails
                        join ld in context.LookupDatas on vd.VesselTypeId equals ld.LookupDataId into ldt
                        from ldata in ldt.DefaultIfEmpty()
                        join re in context.ReportableEvents on vd.ReportableEventId equals re.ReportableEventId
                        join rc in context.ReportableCategories on re.CategoryId equals rc.CategoryId
                        join rd in context.ReportableEventDetails on re.ReportableEventId equals rd.ReportableEventId into rdt
                        from edt in rdt.DefaultIfEmpty()
                        join es in context.EventSeverities on edt.EventSeverityId equals es.EventSeverityId into esv
                        from sev in esv.DefaultIfEmpty()
                        join ps in context.Personnels on edt.AssigneeId equals ps.PersonnelId into per
                        from psn in per.DefaultIfEmpty()
                        join status in context.EventStatus on edt.EventStatusId equals status.EventStatusId into est
                        from estatus in est.DefaultIfEmpty()
                        where re.IsInternalReview == false && re.SubmitToShip == false
                        where vd.VesselName.Contains(search) || ldata.LookupDataName.Contains(search)
                        || rc.CategoryName.Contains(search) || sev.EventSeverityName.Contains(search)
                        || estatus.EventStatus.Contains(search)
                        || psn.PersonnelName.Contains(search)
                        || vd.BriefDescription.Contains(search)
                        select new
                        {
                            EventId = string.Concat(re.ReportableEventId, " ", re.CreatedDt.Value.Year),
                            re.ReportableEventId,
                            vd.VesselName,
                            vd.VesselDetailId,
                            VesselType = ldata.LookupDataName,
                            EventType = rc.CategoryName,
                            vd.DateofEvent,
                            sev.EventSeverityName,
                            estatus.EventStatus,
                            Assignee = psn.PersonnelName,
                            vd.BriefDescription
                        };
                string vesselName = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault().Trim();
                string vesselType = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault().Trim();
                string eventDate = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault().Trim();

                if (!string.IsNullOrEmpty(vesselName))
                {
                    v = v.Where(a => a.VesselName.Contains(vesselName));
                }
                if (!string.IsNullOrEmpty(vesselType))
                {
                    v = v.Where(a => a.VesselType.Contains(vesselType));
                }
                if (!string.IsNullOrEmpty(eventDate))
                {
                    DateTime dateTime = DateTime.ParseExact(eventDate, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    v = v.Where(a => a.DateofEvent == dateTime);
                }
                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                }

                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MvcGrid()
        {
            return View();
        }

        public IEnumerable<ReportableEventGrid> GetData(Int32? page, Int32? rows)
        {
            List<ReportableEventGrid> reportableEventGrids = new List<ReportableEventGrid>();
            using (var context = new BMA_DEVEntities())
            {

                var dbData = from vd in context.VesselDetails
                             join ld in context.LookupDatas on vd.VesselTypeId equals ld.LookupDataId into ldt
                             from ldata in ldt.DefaultIfEmpty()
                             join re in context.ReportableEvents on vd.ReportableEventId equals re.ReportableEventId
                             join rc in context.ReportableCategories on re.CategoryId equals rc.CategoryId
                             join rd in context.ReportableEventDetails on re.ReportableEventId equals rd.ReportableEventId into rdt
                             from edt in rdt.DefaultIfEmpty()
                             join es in context.EventSeverities on edt.EventSeverityId equals es.EventSeverityId into esv
                             from sev in esv.DefaultIfEmpty()
                             join ps in context.Personnels on edt.AssigneeId equals ps.PersonnelId into per
                             from psn in per.DefaultIfEmpty()
                             join status in context.EventStatus on edt.EventStatusId equals status.EventStatusId into est
                             from estatus in est.DefaultIfEmpty()
                             where re.IsInternalReview == false && re.SubmitToShip == false
                             select new
                             {
                                 EventId = string.Concat(re.ReportableEventId, " ", re.CreatedDt.Value.Year),
                                 re.ReportableEventId,
                                 vd.VesselName,
                                 vd.VesselDetailId,
                                 VesselType = ldata.LookupDataName,
                                 EventType = rc.CategoryName,
                                 vd.DateofEvent,
                                 sev.EventSeverityName,
                                 estatus.EventStatus,
                                 Assignee = psn.PersonnelName,
                                 vd.BriefDescription
                             };
                ViewBag.TotalRows = dbData.Count();
                var res = dbData.Skip((page - 1 ?? 0) * (rows ?? 10)).Take(rows ?? 10);
                foreach (var v in res.ToList())
                {
                    ReportableEventGrid reportableEventGrid = new ReportableEventGrid
                    {
                        Assignee = v.Assignee,
                        BriefDescription = v.BriefDescription,
                        Event = v.EventId,
                        EventDate = v.DateofEvent.Value,
                        EventType = v.EventType,
                        ReportableEventId = v.ReportableEventId,
                        Severity = v.EventSeverityName,
                        Status = v.EventStatus,
                        VesselName = v.VesselName,
                        VesselDetailId = v.VesselDetailId,
                        VesselType = v.VesselType
                    };
                    reportableEventGrids.Add(reportableEventGrid);

                }
            }
            return reportableEventGrids;
        }

    }
}