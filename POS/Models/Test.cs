using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class TestParent
    {
        public int TestParentId { get; set; }
        [DisplayName("Parent Name")]
        public string Name { get; set; }
        public ICollection<TestChild> TestChilds { get; set; }

    }
    public class TestChild
    {
        public int TestChildId { get; set; }
        [DisplayName("TestChild Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int TestParentId { get; set; }
        public TestParent TestParent { get; set; }

    }
    public class TestChildVM
    {
        public int TestChildId { get; set; }
        [DisplayName("TestChild Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int TestParentId { get; set; }

       

    }
    public class TestChildVM2
    {

       
        public string Name { get; set; }
        public int Age { get; set; }
        //public int TestParentId { get; set; }

        public List<TestChild> TestChildData{ get; set; }

    }
}
