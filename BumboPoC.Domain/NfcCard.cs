using System.ComponentModel.DataAnnotations;

namespace BumboPoC.Domain
{
	public class NfcCard
	{
		[Key]
		public string Id { get; set; }
	}
}