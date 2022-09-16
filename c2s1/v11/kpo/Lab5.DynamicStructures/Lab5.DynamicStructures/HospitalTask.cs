namespace Lab5;

public class HospitalTask
{
    public class Patient
    {
        public string Name;
        private int _location;
        private Hospital? _hospital;

        public Patient(string name, int location, List<Hospital> hospitals)
        {
            Name = name;
            _location = location;
            
            // start with the closest hospital
            foreach (var hospital in hospitals.OrderBy(x => x.Distance(_location)))
            {
                if (hospital.AddPatient(this))
                {
                    _hospital = hospital;
                    return;
                }
            }
            
            if(_hospital is null)
                Console.WriteLine($"All hospitals are full, {Name} is going to die");
        }
    }
    
    public struct Hospital
    {
        private Queue<Patient> _space;
        private int _location;
        private int _capacity;


        public Hospital(int space, int location)
        {
            _space = new Queue<Patient>();
            _capacity = space;
            _location = location;
        }

        public int Distance(int patientLocation)
        {
            return Math.Abs(_location - patientLocation);
        }

        public bool AddPatient(Patient patient)
        {
            if (_space.Count != _capacity)
            {
                Console.WriteLine($"The patient was admitted to the nearest free hospital");
                _space.Enqueue(patient);
                return true;
            }

            return false;
        }
        
        public bool DischargePatient()
        {
            if (_space.Count != 0)
            {
                Console.WriteLine($"The patient {_space.Dequeue().Name} was discharged");
                return true;
            }
            Console.WriteLine($"The hospital is empty");
            return false;
        }
        
        public void PrintInfo()
        {
            Console.WriteLine($"Number of seats : \t{_capacity}");
            Console.WriteLine($"Number of available seats :  \t{_capacity - _space.Count}");
            Console.WriteLine("At the moment there are:");
            foreach (var patient in _space)
            {
                Console.WriteLine($"\t{patient.Name};");
            }
        }
    }
    
    

}