using Persons.Console.Entities;
using System.Text;

namespace Persons.Console.Repositories
{
    //DAO Data Access Object, es el almacenista y almacen
    public  class PersonRespository
    {
        /// <summary>
        /// Por convención de  .NET las variables globales van con guion bajo
        /// </summary>
        public List<PersonEntity> _personEntities { get; set; }

        /// <summary>
        /// En el contructor inicializamos la lista de personas
        /// Es la obtencion de datos
        /// </summary>
        public PersonRespository()
        {
            //FromMemory();
            FromFile();
        }

        /// <summary>
        /// Origen de datos desde un archivo
        /// </summary>
        private void FromFile()
        {
            string path;
            string[] lines;

            path = "Repositories\\Persons.txt";
            //Se lee el archivo, el segundo parametro es para que
            //lea los caracteres especiales
            lines = File.ReadAllLines(path,Encoding.UTF8);
            //Inicializamos la lista
            _personEntities = new List<PersonEntity>();
            //1|Angel|Rdriguez|true
            foreach (var line in lines)
            {
                string[] pieces;
                PersonEntity personEntity;

                //Separamos en partes por medio de pipes (|)
                pieces = line.Split("|");
                //instanciamos y llenamos el objeto
                personEntity = new PersonEntity
                {
                    Id = Convert.ToInt32(pieces[0]),
                    Name = pieces[1],
                    LastName = pieces[2],
                    IsActive = Convert.ToBoolean(pieces[3])
                };
                //Agregamos el objeto a la lista
                _personEntities.Add(personEntity);
            }
        }

        private void FromMemory()
        {
            //Iniciamos la lista
            _personEntities = new List<PersonEntity>();

            //Creamos a la primera persona y agregamos los datos
            PersonEntity personEntity01 = new PersonEntity();
            personEntity01.Id = 1;
            personEntity01.Name = "Angel";
            personEntity01.LastName = "Rodriguez";
            personEntity01.Birthday = DateTime.Now;
            personEntity01.DateRegistration = DateTime.Now;
            personEntity01.IsActive = true;

            //Agregamos a la segunda persona y agregamos los datos
            PersonEntity personEntity02 = new PersonEntity();
            personEntity02.Id = 2;
            personEntity02.Name = "Nicolas";
            personEntity02.LastName = "Gonzalez";
            personEntity02.Birthday = DateTime.Now;
            personEntity02.DateRegistration = DateTime.Now;
            personEntity02.IsActive = true;

            //Agregamos las personas a la lista
            _personEntities.Add(personEntity01);
            _personEntities.Add(personEntity02);
        }



        /// <summary>
        /// Regresa la lista de la personas
        /// </summary>
        /// <returns></returns>
        public List<PersonEntity> GetAll()
        {
            return _personEntities;
        }
    }//end classs
}
