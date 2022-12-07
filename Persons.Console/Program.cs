// See https://aka.ms/new-console-template for more information
using Persons.Console.Entities;
using Persons.Console.Repositories;

Console.WriteLine("Demo para lista de personas");

//Declaramos la lista de personas
List<PersonEntity> list;

//Instanciamos el objecto
PersonRespository respository = new PersonRespository();
//Le pedimos al repositorio la lista
list = respository.GetAll();

//Recorremos las lista e imprimimos el id y el nombre
foreach (var item in list)
{
    Console.WriteLine(item.Id + " " + item.Name);
}
