using Infraestructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Condominium.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReporteIngresos()
        {
            int year = DateTime.Now.Year;
            dynamic chartData = null;
            dynamic chartOptions = null;
            using (var db = new MyContext())
            {
                var ingresosPorMes = db.GESTION_PLANES_COBRO
                .Where(gpc => gpc.FECHA_INICIO != null && gpc.FECHA_INICIO.Value.Year == year)
                .GroupBy(gpc => gpc.FECHA_INICIO.Value.Month)
                .Select(group => new
                {
                    Mes = group.Key,
                    Ingresos = group.Sum(gpc => gpc.PLAN_COBRO.TOTAL)
                })
                .ToList();
                chartData = new
                {
                    labels = ingresosPorMes.Select(ipm => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ipm.Mes)),
                    datasets = new[] {
                new {
                    label = "Ingresos",
                    data = ingresosPorMes.Select(ipm => ipm.Ingresos),
                    backgroundColor = "rgba(75, 192, 192, 0.2)",
                    borderColor = "rgba(75, 192, 192, 1)",
                    borderWidth = 1
                }
            }
                };

                chartOptions = new
                {
                    scales = new
                    {
                        yAxes = new[] {
                    new {
                        ticks = new {
                            beginAtZero = true
                        }
                    }
                }
                    }
                };
            }

            ViewBag.ChartData = JsonConvert.SerializeObject(chartData);
            ViewBag.ChartOptions = JsonConvert.SerializeObject(chartOptions);

            return View();
        }
    }
}