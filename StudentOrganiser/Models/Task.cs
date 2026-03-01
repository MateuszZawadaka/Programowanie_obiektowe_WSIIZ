using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganiser.Models
{
  class Task
  {
    private int Id { get; set; }
    public string name { get; set; }

    public Task(string name)
    {
      Id = Id + 1;
      this.name = name;
    }
  }
}
