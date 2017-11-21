using KvasDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvasLogic
{
    public class PersonasLogic
    {
        private PersonaDAL objPersonaDAL;
        private bool validacion = true;
        public PersonasLogic()
        {
            objPersonaDAL = new PersonaDAL();
        }
    }
}
