
//in .Net we use the HTTPClient class to make http requests 

//create a new instance of HTTPCLient
using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client = new();
//set the BaseAddress property to the url of the Api
//you can find the address in the launchesettings of the api project under profiles - applicationUrl
client.BaseAddress = new Uri("https://localhost:7255");
//tell the server we want the result in json format
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//then retrieve all the issues
HttpResponseMessage response = await client.GetAsync("api/issue"); //makes a GET request from API 
response.EnsureSuccessStatusCode(); //to make sure it succeeds
if(response.IsSuccessStatusCode)
{//if successful use content property and invoke readfromjsonasync method to deserialize the content of response to IEnumerableIssueDto
    var issues = await response.Content.ReadFromJsonAsync <IEnumerable<IssueDto>>();

    //then iterate over the results to display the title foreach issue
    //if no issue to display then display null message
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Title);
    }
}
else
{
    Console.WriteLine("No Results");
}

