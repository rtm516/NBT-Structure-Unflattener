using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTConvert
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Loading file...");

			NbtFile nbtFile = new NbtFile();
			nbtFile.LoadFromFile(@"C:\Users\ryant\Documents\tmp\NewSpawnHUB.nbt");
			Console.WriteLine("File loaded");

			NbtList blockPalette = nbtFile.RootTag.Get<NbtList>("palette");

			Console.WriteLine("Changing blocks and fixing properties");
			foreach (NbtCompound block in blockPalette.ToArray<NbtCompound>())
			{
				NbtString name = new NbtString();
				NbtCompound properties = null;

				foreach (NbtTag tag in block)
				{
					if (tag.Name == "Name")
					{
						name = (NbtString) tag;
					}
					else if(tag.Name == "Properties")
					{
						properties = (NbtCompound)tag;
					}
				}

				if (properties == null)
				{
					properties = new NbtCompound("Properties");
					block.Add(properties);
				}

				switch (name.StringValue)
				{
					case "minecraft:grass_block":
						name.Value = "minecraft:grass";
						break;
					case "minecraft:grass":
						name.Value = "minecraft:tallgrass";
						break;
					case "minecraft:dandelion":
						name.Value = "minecraft:yellow_flower";
						break;
					case "minecraft:poppy":
						name.Value = "minecraft:red_flower";
						break;
					case "minecraft:wall_torch":
						name.Value = "minecraft:torch";
						if (properties.Get<NbtString>("facing") == null)
						{
							properties.Add(new NbtString("facing", "north"));
						}
						break;
					case "minecraft:oak_fence":
						name.Value = "minecraft:fence";
						break;
					case "minecraft:oak_fence_gate":
						name.Value = "minecraft:fence_gate";
						break;
					case "minecraft:lily_pad":
						name.Value = "minecraft:waterlily";
						break;
					case "minecraft:oak_trapdoor":
						name.Value = "minecraft:trapdoor";
						break;
					case "minecraft:cobblestone_stairs":
						name.Value = "minecraft:stone_stairs";
						break;

					case "minecraft:fern":
						name.Value = "minecraft:tallgrass";
						properties.Add(new NbtString("type", "fern"));
						break;

					// Flowers
					case "minecraft:blue_orchid":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "blue_orchid"));
						break;
					case "minecraft:allium":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "allium"));
						break;
					case "minecraft:azure_bluet":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "houstonia"));
						break;
					case "minecraft:red_tulip":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "red_tulip"));
						break;
					case "minecraft:orange_tulip":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "orange_tulip"));
						break;
					case "minecraft:white_tulip":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "white_tulip"));
						break;
					case "minecraft:pink_tulip":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "pink_tulip"));
						break;
					case "minecraft:oxeye_daisy":
						name.Value = "minecraft:red_flower";
						properties.Add(new NbtString("type", "oxeye_daisy"));
						break;

					// Leaves
					case "minecraft:oak_leaves":
						name.Value = "minecraft:leaves";
						properties.Add(new NbtString("variant", "oak"));
						break;
					case "minecraft:spruce_leaves":
						name.Value = "minecraft:leaves";
						properties.Add(new NbtString("variant", "spruce"));
						break;
					case "minecraft:birch_leaves":
						name.Value = "minecraft:leaves";
						properties.Add(new NbtString("variant", "birch"));
						break;
					case "minecraft:jungle_leaves":
						name.Value = "minecraft:leaves";
						properties.Add(new NbtString("variant", "jungle"));
						break;
					case "minecraft:acacia_leaves":
						name.Value = "minecraft:leaves2";
						properties.Add(new NbtString("variant", "acacia"));
						break;
					case "minecraft:dark_oak_leaves":
						name.Value = "minecraft:leaves2";
						properties.Add(new NbtString("variant", "dark_oak"));
						break;

					// Logs
					case "minecraft:oak_log":
						name.Value = "minecraft:log";
						properties.Add(new NbtString("variant", "oak"));
						break;
					case "minecraft:spruce_log":
						name.Value = "minecraft:log";
						properties.Add(new NbtString("variant", "spruce"));
						break;
					case "minecraft:birch_log":
						name.Value = "minecraft:log";
						properties.Add(new NbtString("variant", "birch"));
						break;
					case "minecraft:jungle_log":
						name.Value = "minecraft:log";
						properties.Add(new NbtString("variant", "jungle"));
						break;
					case "minecraft:oak_wood":
						name.Value = "minecraft:log";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "oak"));
						break;
					case "minecraft:spruce_wood":
						name.Value = "minecraft:log";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "spruce"));
						break;
					case "minecraft:birch_wood":
						name.Value = "minecraft:log";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "birch"));
						break;
					case "minecraft:jungle_wood":
						name.Value = "minecraft:log";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "jungle"));
						break;
					case "minecraft:acacia_log":
						name.Value = "minecraft:log2";
						properties.Add(new NbtString("variant", "acacia"));
						break;
					case "minecraft:dark_oak_log":
						name.Value = "minecraft:log2";
						properties.Add(new NbtString("variant", "dark_oak"));
						break;
					case "minecraft:acacia_wood":
						name.Value = "minecraft:log2";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "acacia"));
						break;
					case "minecraft:dark_oak_wood":
						name.Value = "minecraft:log2";
						properties.Remove("axis");
						properties.Add(new NbtString("axis", "none"));
						properties.Add(new NbtString("variant", "dark_oak"));
						break;

					// Planks
					case "minecraft:oak_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "oak"));
						break;
					case "minecraft:spruce_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "spruce"));
						break;
					case "minecraft:birch_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "birch"));
						break;
					case "minecraft:jungle_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "jungle"));
						break;
					case "minecraft:acacia_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "acacia"));
						break;
					case "minecraft:dark_oak_planks":
						name.Value = "minecraft:planks";
						properties.Add(new NbtString("variant", "dark_oak"));
						break;

					// Stone
					case "minecraft:granite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "granite"));
						break;
					case "minecraft:polished_granite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "smooth_granite"));
						break;
					case "minecraft:diorite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "diorite"));
						break;
					case "minecraft:polished_diorite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "smooth_diorite"));
						break;
					case "minecraft:andesite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "andesite"));
						break;
					case "minecraft:polished_andesite":
						name.Value = "minecraft:stone";
						properties.Add(new NbtString("variant", "smooth_andesite"));
						break;

					// Dirt
					case "minecraft:coarse_dirt":
						name.Value = "minecraft:dirt";
						properties.Add(new NbtString("variant", "coarse_dirt"));
						break;
					case "minecraft:podzol":
						name.Value = "minecraft:dirt";
						properties.Add(new NbtString("variant", "podzol"));
						break;

					// Wool
					case "minecraft:white_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "white"));
						break;
					case "minecraft:orange_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "orange"));
						break;
					case "minecraft:magenta_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "magenta"));
						break;
					case "minecraft:light_blue_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "light_blue"));
						break;
					case "minecraft:yellow_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "yellow"));
						break;
					case "minecraft:lime_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "lime"));
						break;
					case "minecraft:pink_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "pink"));
						break;
					case "minecraft:gray_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "gray"));
						break;
					case "minecraft:light_gray_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "light_gray"));
						break;
					case "minecraft:cyan_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "cyan"));
						break;
					case "minecraft:purple_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "purple"));
						break;
					case "minecraft:blue_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "blue"));
						break;
					case "minecraft:brown_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "brown"));
						break;
					case "minecraft:green_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "green"));
						break;
					case "minecraft:red_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "red"));
						break;
					case "minecraft:black_wool":
						name.Value = "minecraft:wool";
						properties.Add(new NbtString("color", "black"));
						break;

					// Stone bricks
					case "minecraft:stone_bricks":
						name.Value = "minecraft:stonebrick";
						break;
					case "minecraft:mossy_stone_bricks":
						name.Value = "minecraft:stonebrick";
						properties.Add(new NbtString("variant", "mossy_stonebrick"));
						break;
					case "minecraft:cracked_stone_bricks":
						name.Value = "minecraft:stonebrick";
						properties.Add(new NbtString("variant", "cracked_stonebrick"));
						break;
					case "minecraft:chiseled_stone_bricks":
						name.Value = "minecraft:stonebrick";
						properties.Add(new NbtString("variant", "chiseled_stonebrick"));
						break;

					// Stone slab
					case "minecraft:smooth_stone_slab":
						name.Value = "minecraft:stone_slab";
						break;
					case "minecraft:sandstone_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "sandstone"));
						break;
					case "minecraft:cobblestone_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "cobblestone"));
						break;
					case "minecraft:brick_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "brick"));
						break;
					case "minecraft:stone_brick_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "stone_brick"));
						break;
					case "minecraft:nether_brick_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "nether_brick"));
						break;
					case "minecraft:quartz_slab":
						name.Value = "minecraft:stone_slab";
						properties.Add(new NbtString("variant", "quartz"));
						break;
					case "minecraft:red_sandstone_slab":
						name.Value = "minecraft:stone_slab2";
						properties.Add(new NbtString("variant", "red_sandstone"));
						break;

					// Wood slab
					case "minecraft:oak_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "oak"));
						break;
					case "minecraft:spruce_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "spruce"));
						break;
					case "minecraft:birch_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "birch"));
						break;
					case "minecraft:jungle_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "jungle"));
						break;
					case "minecraft:acacia_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "acacia"));
						break;
					case "minecraft:dark_oak_slab":
						name.Value = "minecraft:wooden_slab";
						properties.Add(new NbtString("variant", "dark_oak"));
						break;

					// Prismarine
					case "minecraft:prismarine_bricks":
						name.Value = "minecraft:prismarine";
						properties.Add(new NbtString("variant", "prismarine_bricks"));
						break;
					case "minecraft:dark_prismarine":
						name.Value = "minecraft:prismarine";
						properties.Add(new NbtString("variant", "dark_prismarine"));
						break;

					// Double plant
					case "minecraft:sunflower":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "sunflower"));
						break;
					case "minecraft:lilac":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "syringa"));
						break;
					case "minecraft:tall_grass":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "double_grass"));
						break;
					case "minecraft:large_fern":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "double_fern"));
						break;
					case "minecraft:rose_bush":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "double_rose"));
						break;
					case "minecraft:peony":
						name.Value = "minecraft:double_plant";
						properties.Add(new NbtString("variant", "paeonia"));
						break;

					default:
						break;
				}

				// Slab fix
				if (name.StringValue.Contains("slab"))
				{
					if (properties.Get<NbtString>("type") != null) { 
						string type = properties.Get<NbtString>("type").StringValue;
						if (type == "double")
						{
							name.Value = name.StringValue.Replace("minecraft:", "minecraft:double_");
						}
						else
						{
							properties.Add(new NbtString("half", type));
						}
					}
					else
					{
						properties.Add(new NbtString("half", "top"));
					}
				}

				// Facing fix
				if (properties.Get<NbtString>("facing") != null)
				{
					NbtString facing = properties.Get<NbtString>("facing");
					facing.Value = facing.StringValue.ToLower();
				}

					if (properties.Count == 0)
				{
					block.Remove("Properties");
				}

				// Stairs fix
				if (name.StringValue.Contains("stairs"))
				{
					if (properties.Get<NbtString>("facing") == null)
					{
						properties.Add(new NbtString("facing", "north"));
					}

					if (properties.Get<NbtString>("half") == null)
					{
						properties.Add(new NbtString("half", "top"));
					}
				}

				// Trapdoor fix
				if (name.StringValue.Contains("trapdoor"))
				{
					if (properties.Get<NbtString>("facing") == null)
					{
						properties.Add(new NbtString("facing", "north"));
					}

					if (properties.Get<NbtString>("half") == null)
					{
						properties.Add(new NbtString("half", "top"));
					}

					if (properties.Get<NbtString>("open") == null)
					{
						properties.Add(new NbtString("open", "true"));
					}
				}

				// Log fix
				if (name.StringValue.Contains("log"))
				{
					if (properties.Get<NbtString>("axis") == null)
					{
						properties.Add(new NbtString("axis", "x"));
					}
				}

				// Vine fix
				if (name.StringValue.Contains("vine"))
				{
					NbtString east = properties.Get<NbtString>("east");
					if (east == null)
					{
						properties.Add(new NbtString("facing", "east"));
						continue;
					}

					NbtString south = properties.Get<NbtString>("south");
					if (south == null)
					{
						properties.Add(new NbtString("facing", "south"));
						continue;
					}

					NbtString north = properties.Get<NbtString>("north");
					if (north == null)
					{
						properties.Add(new NbtString("facing", "north"));
						continue;
					}

					NbtString west = properties.Get<NbtString>("west");
					if (west == null)
					{
						properties.Add(new NbtString("facing", "west"));
						continue;
					}
				}

				// Double plant fix
				if (name.StringValue.Contains("double_plant"))
				{
					if (properties.Get<NbtString>("half") == null)
					{
						properties.Add(new NbtString("half", "upper"));
					}
				}
			}

			Console.WriteLine("Saving file");

			nbtFile.SaveToFile(@"C:\Users\ryant\Documents\tmp\NewSpawnHUB-Converted.nbt", nbtFile.FileCompression);

			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
