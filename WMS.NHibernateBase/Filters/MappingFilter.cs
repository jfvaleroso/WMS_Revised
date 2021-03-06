﻿using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.NHibernateBase.Filters
{
    public class MappingFilter
    {
        #region Main Search
        public static List<Order> Orders()
        {
            List<Order> orderList = new List<Order>();
            return orderList;
        }
        public static Dictionary<string, string> Alias { get; set; }
        public static List<ICriterion> Search(string nodeId)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
                //add cretrion
           Conjunction conjunction = Restrictions.Conjunction();

                if (!string.IsNullOrEmpty(nodeId))
                {
                    aliases.Add("Node", "n");
                    conjunction.Add(Restrictions.Eq("n.Id", Convert.ToInt64(nodeId)));
                }
               
                Alias = aliases;
                criterion.Add(conjunction);
                return criterion;
        }
        public static List<ICriterion> Search(string nodeId, int levelId)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            //add cretrion
            Conjunction conjunction = Restrictions.Conjunction();

            if (!string.IsNullOrEmpty(nodeId))
            {
                aliases.Add("Node", "n");
                conjunction.Add(Restrictions.Eq("n.Id", Convert.ToInt64(nodeId)));
            }
           
            conjunction.Add(Restrictions.Eq("LevelId", levelId));


            Alias = aliases;
            criterion.Add(conjunction);
            return criterion;
        }
        public static List<ICriterion> Search(string nodeId, string status)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            Dictionary<string, string> aliases = new Dictionary<string, string>();
            //add cretrion
            Conjunction conjunction = Restrictions.Conjunction();

            if (!string.IsNullOrEmpty(nodeId))
            {
                aliases.Add("Node", "n");
                conjunction.Add(Restrictions.Eq("n.Id", Convert.ToInt64(nodeId)));
            }
            if (!string.IsNullOrEmpty(status))
            {
                aliases.Add("Status", "s");
                conjunction.Add(Restrictions.Eq("s.Code", status));
            }


            Alias = aliases;
            criterion.Add(conjunction);
            return criterion;
        }

        #endregion
    }
}
