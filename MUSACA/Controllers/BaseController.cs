namespace MUSACA.Controllers
{
    using Data;
    using SIS.MvcFramework;

    public abstract class BaseController:Controller
    {
        public BaseController(MusacaDb musacaDb)
        {
            this.Db = musacaDb;
        }

        public MusacaDb Db { get; }
    }
}
