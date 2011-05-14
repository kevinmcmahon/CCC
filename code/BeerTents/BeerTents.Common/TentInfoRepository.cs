using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BeerTents.Common
{
	public class TentInfoRepository
	{
		XElement _tentsXElement;
		List<Tent> _tents;
		
        public TentInfoRepository(string file)
        {
			_tentsXElement = XElement.Load(file);
		}
		
		public TentInfoRepository(TextReader stream) 
		{
			_tentsXElement = XElement.Load(stream);
		}
		
        public List<Tent> GetAll()
        {
            if (_tents == null)
            {
        		var tents = from h in _tentsXElement.Elements("tent")
						select new Tent
						{
							Id = int.Parse(h.Attribute("id").Value),
							TentType = h.Attribute("type").Value.ToString().Equals("big") ? TentType.Big : TentType.Small,
							Name = h.Element("name").Value,
							Proprietor = h.Element("proprietor").Value,
							PhoneNumber = h.Element("phone_number").Value,
							FaxNumber = h.Element("fax_number").Value,
							Url = h.Element("url").Value,
							SeatingInside = h.Element("seating_inside").Value,
							SeatingOutside = h.Element("seating_outside").Value,
							Brewery = h.Element("brewery").Value,
							Music = h.Element("music").Value,
							Notes = h.Element("notes").Value,
					 	};
				_tents = tents.ToList();
            }
            return _tents;	
        }
	}
}

