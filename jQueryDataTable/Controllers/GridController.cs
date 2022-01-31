using jQueryDataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryDataTable.Controllers
{
    public class GridController : Controller
    {
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult IndexGrid(int? page, int? rows, string search)
        {
            var result = GetData(page, rows);
            //ViewBag.TotalRows = result.Count();
            //return PartialView("IndexGrid", result.Skip((page - 1 ?? 0) * (rows ?? 10)).Take(rows ?? 10));
            return PartialView("IndexGrid", result);
        }

        public IEnumerable<ReportableEventGrid> GetData(int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
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
                dbData = dbData.OrderByDescending(x => x.ReportableEventId);
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