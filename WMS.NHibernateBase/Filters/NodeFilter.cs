using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.NHibernateBase.Filters
{
    public class NodeFilter
    {
        #region Main Search
        public static List<Order> Orders()
        {
            List<Order> orderList = new List<Order>();
            return orderList;
        }
        public static Dictionary<string, string> Alias { get; set; }
        public static List<ICriterion> Search(string searchString, long id)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(searchString))
            {
                //add alias               
                aliases.Add("Workflow", "w");
                aliases.Add("Process", "p");
                Alias = aliases;
                //add cretrion
                ICriterion workflow = Restrictions.Eq("w.Id", id);
                ICriterion process = Restrictions.Or(
                NHibernate.Criterion.Restrictions.Like("p.Code", searchString, MatchMode.Anywhere),
                NHibernate.Criterion.Restrictions.Like("p.Name", searchString, MatchMode.Anywhere)
                );
                //and logic
                ICriterion logic = Restrictions.And(workflow, process);
                criterion.Add(logic);

                // Disjunction or
                //Disjunction p = Restrictions.Disjunction();
                //p.Add(NHibernate.Criterion.Restrictions.Like("p.Code", searchString, MatchMode.Anywhere));
                //p.Add(NHibernate.Criterion.Restrictions.Like("p.Name", searchString, MatchMode.Anywhere));
                ////Conjunction means And
                //Conjunction w = Restrictions.Conjunction();
                //p.Add(Restrictions.Eq("w.Id", id));
                //p.Add(p);
                //criterion.Add(w);




            }
            else
            {
                //set alias
                aliases.Add("Workflow", "w");
                Alias = aliases;
                //add criterion
                criterion.Add(Restrictions.Eq("w.Id", id));
            }
            return criterion;
        }
        public static List<ICriterion> Search(string workflow, string process, string subProcess, string classification)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
                //add cretrion
           Conjunction conjunction = Restrictions.Conjunction();

                if (!string.IsNullOrEmpty(workflow) || workflow != "0")
                {
                    aliases.Add("Workflow", "w");
                    conjunction.Add(Restrictions.Eq("w.Id", Convert.ToInt64(workflow)));
                }
                else
                {
                    conjunction.Add(Restrictions.IsNull("Workflow"));
                }
                if (!string.IsNullOrEmpty(process))
                {
                    aliases.Add("Process", "p");
                    conjunction.Add(Restrictions.Eq("p.Id", Convert.ToInt32(process)));
                }
                else
                {
                    conjunction.Add(Restrictions.IsNull("Process"));
                }
                //subprocess
                if (!string.IsNullOrEmpty(subProcess))
                {
                    aliases.Add("SubProcess", "s");
                    conjunction.Add(Restrictions.Eq("s.Id", Convert.ToInt32(subProcess)));
                }
                else
                {
                    conjunction.Add(Restrictions.IsNull("SubProcess"));
                }
                //classification
                if (!string.IsNullOrEmpty(classification))
                {
                    aliases.Add("Classification", "c");
                    conjunction.Add(Restrictions.Eq("c.Id", Convert.ToInt32(classification)));
                }
                else
                {
                    conjunction.Add(Restrictions.IsNull("Classification"));
                }
                Alias = aliases;
                criterion.Add(conjunction);
                return criterion;
        }
        public static List<ICriterion> SearchByCode(string workflow, string process, string subProcess, string classification, string value)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            //add cretrion
            Conjunction conjunction = Restrictions.Conjunction();

            if (!string.IsNullOrEmpty(workflow) && !workflow.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("Workflow", "w");
                conjunction.Add(Restrictions.Eq("w.Code", workflow));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Workflow"));
            }
            if (!string.IsNullOrEmpty(process) && !process.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("Process", "p");
                conjunction.Add(Restrictions.Eq("p.Code", process));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Process"));
            }
            //subprocess
            if (!string.IsNullOrEmpty(subProcess) && !subProcess.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("SubProcess", "s");
                conjunction.Add(Restrictions.Eq("s.Code", subProcess));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("SubProcess"));
            }
            //classification
            if (!string.IsNullOrEmpty(classification) && !classification.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("Classification", "c");
                conjunction.Add(Restrictions.Eq("c.Code", classification));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Classification"));
            }
            Alias = aliases;
            criterion.Add(conjunction);
            return criterion;
        }
        public static List<ICriterion> SearchByCode(string workflow, string process, string subProcess, string classification, int level, string value)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            //add cretrion
            Conjunction conjunction = Restrictions.Conjunction();
            conjunction.Add(Restrictions.Eq("LevelId", level));
            if (!string.IsNullOrEmpty(workflow) && !workflow.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("Workflow", "w");
                conjunction.Add(Restrictions.Eq("w.Code", workflow));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Workflow"));
            }
            if (!string.IsNullOrEmpty(process) && !process.Equals(value))
            {
                aliases.Add("Process", "p");
                conjunction.Add(Restrictions.Eq("p.Code", process));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Process"));
            }
            //subprocess
            if (!string.IsNullOrEmpty(subProcess) && !subProcess.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("SubProcess", "s");
                conjunction.Add(Restrictions.Eq("s.Code", subProcess));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("SubProcess"));
            }
            //classification
            if (!string.IsNullOrEmpty(classification) && !classification.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                aliases.Add("Classification", "c");
                conjunction.Add(Restrictions.Eq("c.Code", classification));
            }
            else
            {
                conjunction.Add(Restrictions.IsNull("Classification"));
            }
            Alias = aliases;
            criterion.Add(conjunction);
            return criterion;
        }

        #endregion
    }
}
