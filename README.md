ActionFilters
=============

This project includes two action filter attributes that can be used to decorate controller classes or controller actions to ensure that the currently logged in user has verified the email address based on the new ASP.NET [Identity system][identity].

###Examples

MVC controller action. It can be used on a class level as well.

```
[UserConfirmedFilter]
public ActionResult Contact() {
	ViewBag.Message = "Your contact page.";

	return View();
}
```

Web Api controller class. It can be used on individual controller actions as well.

```
[UserConfirmedWebApiFilterAttribute]
public class ExampleController : ApiController {
	// GET: api/Example
	public IEnumerable<string> Get() {
		return new string[] { "value1", "value2" };
	}
}
```

[identity]: http://www.asp.net/identity  
