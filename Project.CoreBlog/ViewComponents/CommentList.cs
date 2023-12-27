using Microsoft.AspNetCore.Mvc;
using Project.CoreBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.CoreBlog.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					 ID = 1,
					 UserName = "Eren"
				},
				new UserComment
				{
					ID=2,
					UserName="Cansu"
				},
				new UserComment
				{
					ID=3,
					UserName="Yeliz"
				}
			};
			return View(commentvalues);
		}
	}
}
