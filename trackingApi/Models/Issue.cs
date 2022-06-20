using System.ComponentModel.DataAnnotations;

namespace trackingApi.Models
{
    public class Issue
    {
        //will represent a single issue

        //describe an issue
        public int Id { get; set; } //will be the primary key 
        [Required] //validation type
        public string Title { get; set; }
        [Required] //attribute means these properties must have a value
        public string Description { get; set; } 
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        //need to capture the time when an issue was created
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; } //if property is null it means the issue has not been completed yet


    }

    //an issue can have a priority
    public enum Priority
    {
        Low, Medium, High
    }

    public enum IssueType
    {
        //describe the type of an issue
        Feature, Bug, Documentation
    }
}
