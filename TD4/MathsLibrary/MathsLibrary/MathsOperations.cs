using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class MathsOperations : IMathsOperations
    {
        public int test(string value)
        {
            return int.Parse(value);
        }
        public int add(string value1, string value2)
        {
            return int.Parse(value1) + int.Parse(value2);
        }
        public int multiply(int value1, int value2)
        {
            return value1 * value2;
        }
        public int subtract(int value1, int value2)
        {
            return value1 - value2;
        }
        public float divide(int value1, int value2)
        {
            return value1 / value2;
        }

    }
}
