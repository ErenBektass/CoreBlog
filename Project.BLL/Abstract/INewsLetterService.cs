﻿using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
	public interface INewsLetterService
	{
		void AddNewsLetter(NewsLetter newsLetter);
	}
}
