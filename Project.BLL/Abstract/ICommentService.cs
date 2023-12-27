using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
	public interface ICommentService
	{
		//Yorum eklenilecek ve listelenecek
		void CommentAdd(Comment comment);
		List<Comment> GetList(int id);
        List<Comment> GetCommentWithBlog();

    }
}
