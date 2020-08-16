
const Service = require('./Mini_Crud_library');

let film1 =
{
    title: "film 1",
    description: "description 1"
}

let film2 =
{
    title: "film 2",
    description: "description 2"
}

let film3 =
{
    title: "film 3",
    description: "description 3"
}

let film4 =
{
    title: "film 4",
    description: "description 4"
}

let film5 =
{
    title: "film 5",
    description: "description 5"
}

let film6 =
{
    title: "film 6",
    description: "description 6"
}

let film7 =
{
    title: "film 7",
    description: "description 7"
}

let storage = new Service();

storage.add(film1);
storage.add(film2);
storage.add(film3);
storage.add(film4);
storage.add(film5);

console.log("Original content of the film library")
console.log(storage.getAll());

console.log("Checking the method for getting the value by ID - getting a film with ID = 2");
console.log(storage.getById("2"));

storage.deleteById(2);
console.log("Checking the deletion method - deleted the film with ID = 2")
console.log(storage.getAll());

storage.updateById(3, film6);
console.log("Checking the update method - updated the film from ID = 3 to ID = 6")
console.log(storage.getAll());

storage.replaceById(4, film7);
console.log("Checking the replacement method - replaced the film with ID = 4 to ID = 7");
console.log(storage.getAll());