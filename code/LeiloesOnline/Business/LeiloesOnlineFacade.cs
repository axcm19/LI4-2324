using LeiloesOnline.Data;

namespace LeiloesOnline.Business
{
    public class LeiloesOnlineFacade
    {
        private IDatabaseFacade db; // base de dados

        public LeiloesOnlineFacade()
        {
            this.db = new DatabaseFacade();
        }
    }
}
