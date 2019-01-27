using UnityEngine;

namespace CollisionTypes {
	public class CollisionType {

		public string[] sfx;
		public int collBadness;

		public CollisionType(int collBadness, string[] sfx) {
			this.collBadness = collBadness;
			this.sfx = sfx;
		}

		public string getRandomSfx() {
			return sfx[Random.Range(0, sfx.Length)];
		}
	}

	//Wow this is an ugly solution.

	public class Tap : CollisionType {
		public Tap() : base(7, new string[] { "Thump" }) { }
	}

	public class Scrape : CollisionType {
		public Scrape() : base(25, new string[] { "MetalScrape", "Screech1", "Screech2" }) { }
	}

	public class Big : CollisionType {
		public Big() : base(50, new string[] { "WaterBottleCrunch", "Scream" }) { }
	}
}