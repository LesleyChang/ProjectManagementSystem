using Aga.Controls.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWork.Model
{
    public class TreeModel : ITreeModel
    {
        public bool HasChildren(object parent)//當return true表示還有子項目，會在往下增加階層
        {
            return true;
        }

        IEnumerable ITreeModel.GetChildren(object parent)
        {
            if (parent == null)
            {
                for (int i = 1; i <= 10; i++)
                {

                    Project project = new Project { Name = "專案項目", Kind = "一", Data = "1234" };
                    project.Step = i.ToString();
                    yield return project;
                }
            }
            else
            {
                for (int i = 1; i <= 10; i++)
                {
                    Project project = parent as Project;

                    Project subproject = new Project { Name = "專案項目", Kind = "一", Data = "1234" };
                    subproject.Step += project.Step + "." + i;
                    yield return subproject;
                }
            }
        }
    }
}
