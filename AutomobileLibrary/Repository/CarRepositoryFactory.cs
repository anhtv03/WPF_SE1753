using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository {
    public class CarRepositoryFactory {

        public static ICarRepository CreateRepository(string repositoryType) {
            if (repositoryType.Equals("SQLServer")) {
                return new CarRepository();
            } else if (repositoryType.Equals("File")) {
                return new CarFile();
            } else {
                throw new Exception();
            }
        }

    }
}
