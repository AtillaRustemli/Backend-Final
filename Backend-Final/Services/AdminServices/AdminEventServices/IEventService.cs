using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Services.AdminServices.AdminEventServices
{
    public interface IEventService
    {
        public ActionResult Create(EventCreateVM eventCreateVM, int? id, List<int>? speakerIds, Controller controller);
        public ActionResult Delete(int? id, Controller controller);
        public ActionResult Update(EventUpdateVM eventUpdateVM, int id, int? categoryId, List<int>? speakerIds, Controller controller);
    }
}
