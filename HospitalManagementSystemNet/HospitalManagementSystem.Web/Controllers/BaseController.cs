using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Multiplex.DomainServices.Security;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
	public class BaseController: Controller
	{
		private Guid userId = Guid.Empty;
		private Person person = null;

		public Guid UserId
		{
			get
			{
				if(userId == null || userId == Guid.Empty)
				{
					var securityService = new DomainService();
					var userInformation = securityService.GetEntity<HospitalManagementSystemContext, Person>(User.Identity.Name, null);

					if(userInformation != null)
					{
						userId = userInformation.UserId;
					}
				}

				return userId;
			}
		}

		public Person Person
        {
			get
			{
				if(person == null)
				{
					var securityService = new DomainService();

					person = securityService.GetEntity<HospitalManagementSystemContext, Person>(UserId, null);
				}

				return person;
			}
		}

		public Dictionary<string, string> ConvertFormCollection()
		{
			var result = new Dictionary<string, string>();

			foreach(var key in Request.Form.AllKeys)
			{
				result.Add(key, Request.Form[key]);
			}

			return result;
		}
	}
}