using repaso_parcial.BD_Conexion;
using repaso_parcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace repaso_parcial.Controllers
{
    public class ArticulosController : Controller
    {
        //GET: Tipo Articulos
        public ActionResult TipoInstrumentos()
        {
            List<TipoInstrumento> tipoInstrumentos = GestorBd.ObtenerListaTipos();
            ViewBag.tipoInstrumento = tipoInstrumentos;
            return View();
        }
        // GET: Articulos
        public ActionResult ListaInstrumentos()
        {
            List<Articulo> lista = GestorBd.ObtenerListaInstrumentos("");
            ViewBag.tipo = "Instrumentos";
            return View(lista);
        }

        // GET: Articulos por tipo
        public ActionResult ListaEspecifica(string tipo)
        {
            List<Articulo> lista = GestorBd.ObtenerListaInstrumentos(tipo);
            ViewBag.tipo = tipo;
            return View(lista);
        }

        // GET: Articulo Form
        public ActionResult AgregarInstrumento()
        {
            List < TipoInstrumento > tipoInstrumentos = GestorBd.ObtenerListaTipos();
            ViewBag.tipoInstrumentos = tipoInstrumentos;
            return View();
        }

        // POST: Articulo Form
        [HttpPost]
        public ActionResult AgregarInstrumento(Articulo model)
        {
            model.Precio = decimal.Parse(model.PrecioString.ToString());
            if (ModelState.IsValid)
            {
                if (GestorBd.InsertarInstrumento(model))
                {
                    return RedirectToAction("ListaInstrumentos");
                }
                else
                {
                    return View(model);
                }

                
            }
            else
            {
                 return View(model);
            }

        }

        // GET: Articulo edit Form
        public ActionResult EditarInstrumento(int id)
        {
            List<TipoInstrumento> tipoInstrumentos = GestorBd.ObtenerListaTipos();
            ViewBag.tipoInstrumentos = tipoInstrumentos;
            Articulo ar = GestorBd.SeleccionarInstrumento(id);
            return View(ar);
        }

        // POST: Articulo Form
        [HttpPost]
        public ActionResult EditarInstrumento(Articulo model)
        {
            model.Precio = decimal.Parse(model.PrecioString.ToString());
            if (ModelState.IsValid)
            {
                if (GestorBd.EditarInstrumento(model))
                {
                    return RedirectToAction("ListaInstrumentos");
                }
                else
                {
                    return View(model);
                }


            }
            else
            {
                return View(model);
            }

        }
        // GET: Detalle del instrumento para confirmar borrado
        public ActionResult BorrarInstrumento(int id)
        {
            Articulo ar = GestorBd.SeleccionarInstrumento(id);
            return View(ar);

        }

        // POST: Borrar instrumento (borrado suave, marcar actice = 0)
        [HttpPost]
        public ActionResult ConfirmarBorrado(int id)
        {
            GestorBd.BorrarInstrumento(id);
            return RedirectToAction("ListaInstrumentos");

        }
    }
}