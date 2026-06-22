using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;


namespace UserManagementAPI.Controllers
{

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{


static List<User> users = new List<User>
{
    new User
    {
        Id = 1,
        Name="John",
        Email="john@gmail.com",
        Age=20
    }
};



 // GET
[HttpGet]
public IActionResult GetUsers()
{
    return Ok(users);
}





// GET BY ID
[HttpGet("{id}")]
public IActionResult GetUser(int id)
{
    var user = users.FirstOrDefault(x=>x.Id==id);


    if(user == null)
        return NotFound();


    return Ok(user);
}





// POST
[HttpPost]
public IActionResult AddUser(User user)
{

    if(!ModelState.IsValid)
        return BadRequest(ModelState);


    user.Id = users.Count + 1;

    users.Add(user);


    return CreatedAtAction(
        nameof(GetUser),
        new {id=user.Id},
        user
    );
}






// PUT
[HttpPut("{id}")]
public IActionResult UpdateUser(int id, User updatedUser)
{

    var user = users.FirstOrDefault(x=>x.Id==id);


    if(user == null)
        return NotFound();



    if(!ModelState.IsValid)
        return BadRequest(ModelState);



    user.Name = updatedUser.Name;
    user.Email = updatedUser.Email;
    user.Age = updatedUser.Age;



    return Ok(user);

}






// DELETE
[HttpDelete("{id}")]
public IActionResult DeleteUser(int id)
{

    var user = users.FirstOrDefault(x=>x.Id==id);


    if(user == null)
        return NotFound();



    users.Remove(user);


    return Ok("User deleted");

}


}

}