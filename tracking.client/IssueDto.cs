using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracking.client
{
    internal class IssueDto
    {
        //is a data transfer object, similar to the model in the Api, copy properties from the model
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }


    }

    public enum Priority
    {
        Low, Medium, High
    }

    public enum IssueType
    {     
        Feature, Bug, Documentation
    }
}

