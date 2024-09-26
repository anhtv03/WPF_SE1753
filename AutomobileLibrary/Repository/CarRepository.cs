using AutomobileLibrary.Manager;
using AutomobileLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository {
    public class CarRepository : ICarRepository {
        public void DeleteCar(Car car) => CarManagement.Instance.Remove(car);

        public Car GetCarByID(int id) => CarManagement.Instance.GetCarByID(id);

        public List<Car> GetCars() => CarManagement.Instance.GetCarList();

        public void InsertCar(Car car) => CarManagement.Instance.AddNew(car);

        public void UpdateCar(Car car) => CarManagement.Instance.Update(car);
    }
}
