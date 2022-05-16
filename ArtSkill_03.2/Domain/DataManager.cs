using ArtSkill_03._2.Domain.Repositories.Abstract;
using ArtSkill_03._2.Models;

namespace ArtSkill_03._2.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
      


        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            
        }
    }
}
