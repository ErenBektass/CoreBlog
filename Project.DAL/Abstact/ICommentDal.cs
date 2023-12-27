﻿using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstact
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        List<Comment> GetListWithBlog(); // Blog Yorumlar beraber gelicek
    }
}
