using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XMLDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }


        string[] ItemSheetArray = {
            "leather_helmet","chainmail_helmet","iron_helmet","diamond_helmet","golden_helmet","flint_and_steel","flint","coal","string","wheat_seeds","apple","golden_apple","egg","sugar","snowball","elytra" ,
             "leather_chestplate","chainmail_chestplate","iron_chestplate","diamond_chestplate","golden_chestplate","bow","brick","iron_ingot","feather","wheat","painting","sugarcane","bone","cake","slime_ball","broken_elytra" ,
             "leather_leggings","chainmail_leggings","iron_leggings","diamond_leggings","golden_leggings","arrow","end_crystal","gold_ingot","gunpowder","bread","oak_sign","oak_door","iron_door","","fire_charge","chorus_fruit" ,
             "leather_boots","chainmail_boots","iron_boots","diamond_boots","golden_boots","stick","compass_00","diamond","redstone","clay_ball","paper","book","map","pumpkin_seeds","melon_seeds","popped_chorus_fruit" ,
             "wooden_sword","stone_sword","iron_sword","diamond_sword","golden_sword","fishing_rod","clock_00","bowl","mushroom_stew","glowstone_dust","bucket","water_bucket","lava_bucket","milk_bucket","ink_sac","gray_dye" ,
             "wooden_shovel","stone_shovel","iron_shovel","diamond_shovel","golden_shovel","fishing_rod_cast","repeater","porkchop","cooked_porkchop","cod","cooked_cod","rotten_flesh","cookie","shears","red_dye","pink_dye" ,
             "wooden_pickaxe","stone_pickaxe","iron_pickaxe","diamond_pickaxe","golden_pickaxe","bow_pulling_0","carrot_on_a_stick","leather","saddle","beef","cooked_beef","ender_pearl","blaze_rod","melon_slice","green_dye","lime_dye" ,
             "wooden_axe","stone_axe","iron_axe","diamond_axe","golden_axe","bow_pulling_1","baked_potato","potato","carrot","chicken","cooked_chicken","ghast_tear","gold_nugget","nether_wart","cocoa_beans","yellow_dye" ,
             "wooden_hoe","stone_hoe","iron_hoe","diamond_hoe","golden_hoe","bow_pulling_2","poisonous_potato","minecart","oak_boat","glistering_melon_slice","fermented_spider_eye","spider_eye","potion","potion_overlay","blue_dye","light_blue_dye" ,
             "leather_helmet_overlay","spectral_arrow","iron_horse_armor","diamond_horse_armor","golden_horse_armor","comparator","golden_carrot","chest_minecart","pumpkin_pie","spawn_egg","splash_potion","ender_eye","cauldron","blaze_powder","purple_dye","magenta_dye" ,
             "","tipped_arrow_base","dragon_breath","name_tag","lead","nether_brick","tropical_fish","furnace_minecart","charcoal","spawn_egg_overlay","","experience_bottle","brewing_stand","magma_cream","cyan_dye","orange_dye" ,
             "leather_leggings_overlay","tipped_arrow_head","lingering_potion","barrier","mutton","rabbit","pufferfish","hopper_minecart","hopper","nether_star","emerald","writable_book","written_book","flower_pot","light_gray_dye","bone_meal" ,
             "leather_boots_overlay","beetroot","beetroot_seeds","beetroot_soup","cooked_mutton","cooked_rabbit","salmon","tnt_minecart","armor_stand","firework_rocket","firework_star","firework_star_overlay","quartz","map","item_frame","enchanted_book" ,
             "acacia_door","birch_door","dark_oak_door","jungle_door","spruce_door","rabbit_stew","cooked_salmon","command_block_minecart","acacia_boat","birch_boat","dark_oak_boat","jungle_boat","spruce_boat","prismarine_shard","prismarine_crystals","leather_horse_armor" ,
             "structure_void","","totem_of_undying","shulker_shell","iron_nugget","rabbit_foot","rabbit_hide","","","","","","","","","" ,
             "music_disc_13","music_disc_cat","music_disc_blocks","music_disc_chirp","music_disc_far","music_disc_mall","music_disc_mellohi","music_disc_stal","music_disc_strad","music_disc_ward","music_disc_11","music_disc_wait","cod_bucket","salmon_bucket","pufferfish_bucket","tropical_fish_bucket" ,
             "leather_horse_armor","","","","","","","kelp","dried_kelp","sea_pickle","nautilus_shell","heart_of_the_sea","turtle_helmet","scute","trident","phantom_membrane" };


        string[] BlockSheetArray =
            {
             "grass_block_top","stone","dirt","grass_block_side","oak_planks","smooth_stone_slab_side","smooth_stone","bricks","tnt_side","tnt_top","tnt_bottom","cobweb","poppy","dandelion","blue_concrete","oak_sapling" ,
             "cobblestone","bedrock","sand","gravel","oak_log","oak_log_top","iron_block","gold_block","diamond_block","emerald_block","redstone_block","dropper_front","red_mushroom","brown_mushroom","jungle_sapling","red_concrete" ,
             "gold_ore","iron_ore","coal_ore","bookshelf","mossy_cobblestone","obsidian","grass_block_side_overlay","grass","dispenser_front_vertical","beacon","dropper_front_vertical","crafting_table_top","furnace_front","furnace_side","dispenser_front","red_concrete" ,
             "sponge","glass","diamond_ore","redstone_ore","oak_leaves","black_concrete","stone_bricks","dead_bush","fern","daylight_detector_top","daylight_detector_side","crafting_table_side","crafting_table_front","furnace_front_on","furnace_top","spruce_sapling" ,
             "white_wool","spawner","snow","ice","grass_block_snow","cactus_top","cactus_side","cactus_bottom","clay","sugar_cane","jukebox_side","jukebox_top","birch_leaves","mycelium_side","mycelium_top","birch_sapling" ,
             "torch","oak_door_top","iron_door_top","ladder","oak_trapdoor","iron_bars","farmland_wet","farmland","wheat_stage0","wheat_stage1","wheat_stage2","wheat_stage3","wheat_stage4","wheat_stage5","wheat_stage6","wheat_stage7" ,
             "lever","oak_door_bottom","iron_door_bottom","redstone_torch","mossy_stone_bricks","cracked_stone_bricks","pumpkin_top","netherrack","soul_sand","glowstone","piston_top_sticky","piston_top","piston_side","piston_bottom","piston_inner","pumpkin_stem" ,
             "rail_corner","black_wool","gray_wool","redstone_torch_off","spruce_log","birch_log","pumpkin_side","carved_pumpkin","jack_o_lantern","cake_top","cake_side","cake_inner","cake_bottom","red_mushroom_block","brown_mushroom_block","attached_pumpkin_stem" ,
             "rail","red_wool", "pink_wool","repeater","spruce_leaves","spruce_leaves","conduit","turtle_egg","melon_side","melon_top","cauldron_top","cauldron_inner","wet_sponge","mushroom_stem","mushroom_block_inside","vines" ,
             "lapis_block","green_wool","lime_wool","repeater_on","glass_pane_top","debug","debug","turtle_egg_slightly_cracked","turtle_egg_very_cracked","jungle_log","cauldron_side","cauldron_bottom","brewing_stand_base","brewing_stand","end_portal_frame_top","end_portal_frame_side" ,
             "lapis_ore","brown_wool","yellow_wool","powered_rail","redstone_dust_dot","redstone_dust_line0","enchanting_table_top","dragon_egg","cocoa_stage2","cocoa_stage1","cocoa_stage0","emerald_ore","tripwire_hook","tripwire","end_portal_frame_eye","end_stone" ,
             "sandstone_top","blue_wool","light_blue_wool","powered_rail_on","debug","debug","enchanting_table_side","enchanting_table_bottom","ring_blue","item_frame","flower_pot","comparator","comparator_on","activator_rail","activator_rail","nether_quartz_ore" ,
             "sandstone","purple_wool","magenta_wool","detector_rail","jungle_leaves","black_concrete","spruce_planks","jungle_planks","carrots_stage0","carrots_stage1","carrots_stage2","carrots_stage3","slime_block","debug","debug","debug" ,
             "sandstone_bottom","cyan_wool","orange_wool","redstone_lamp","redstone_lamp_on","chiseled_stone_bricks","birch_planks","anvil","chipped_anvil_top","chiseled_quartz_block_top","quartz_pillar_top","quartz_block_side","debug","detector_rail_on","debug","debug" ,
             "nether_bricks","light_gray_wool","nether_wart_stage0","nether_wart_stage1","nether_wart_stage2","chiseled_sandstone","cut_sandstone","anvil_top","damaged_anvil_top","chiseled_quartz_block","quartz_pillar","quartz_block_top","debug","debug","debug","debug" ,
             "debug","debug","debug","debug","debug","debug","debug","debug","debug","debug","hay_block_side","quartz_block_bottom","debug","hay_block_top","debug","debug" ,
             "coal_block","terracotta","note_block","andesite","polished_andesite","diorite","polished_diorite","granite","polished_granite","potatoes_stage0","potatoes_stage1","potatoes_stage2","potatoes_stage3","spruce_log_top","jungle_log_top","birch_log_top" ,
             "black_terracotta","blue_terracotta","brown_terracotta","cyan_terracotta","gray_terracotta","green_terracotta","light_blue_terracotta","lime_terracotta","magenta_terracotta","orange_terracotta","pink_terracotta","purple_terracotta","red_terracotta","light_gray_terracotta","white_terracotta","yellow_terracotta" ,
             "black_stained_glass","blue_stained_glass","brown_stained_glass","cyan_stained_glass","gray_stained_glass","green_stained_glass","light_blue_stained_glass","lime_stained_glass","magenta_stained_glass","orange_stained_glass","pink_stained_glass","purple_stained_glass","red_stained_glass","light_gray_stained_glass","white_stained_glass","yellow_stained_glass" ,
             "black_stained_glass_pane_top","blue_stained_glass_pane_top","brown_stained_glass_pane_top","cyan_stained_glass_pane_top","gray_stained_glass_pane_top","green_stained_glass_pane_top","light_blue_stained_glass_pane_top","lime_stained_glass_pane_top","magenta_stained_glass_pane_top","orange_stained_glass_pane_top","pink_stained_glass_pane_top","purple_stained_glass_pane_top","red_stained_glass_pane_top","light_gray_stained_glass_pane_top","white_stained_glass_pane_top","yellow_stained_glass_pane_top" ,
             "large_fern_top","tall_grass_top","peony_top","rose_bush_top","lilac_top","orange_tulip","sunflower_top","sunflower_front","acacia_log","acacia_log_top","acacia_planks","acacia_leaves","acacia_leaves","prismarine_bricks","red_sand","red_sandstone_top" ,
             "large_fern_bottom","tall_grass_bottom","peony_bottom","rose_bush_bottom","lilac_bottom","pink_tulip","sunflower_bottom","sunflower_back","dark_oak_log","dark_oak_log_top","dark_oak_planks","dark_oak_leaves","dark_oak_leaves","dark_prismarine","red_sandstone_bottom","red_sandstone" ,
             "allium","blue_orchid","azure_bluet","oxeye_daisy","red_tulip","white_tulip","acacia_sapling","dark_oak_sapling","coarse_dirt","podzol_side","podzol_top","spruce_leaves","spruce_leaves","debug","chiseled_red_sandstone","cut_red_sandstone" ,
             "acacia_door_top","birch_door_top","dark_oak_door_top","jungle_door_top","spruce_door_top","chorus_flower","chorus_flower_dead","chorus_plant","end_stone_bricks","grass_path_side","grass_path_top","debug","packed_ice","debug","daylight_detector_inverted_top","iron_trapdoor" ,
             "acacia_door_bottom","birch_door_bottom","dark_oak_door_bottom","jungle_door_bottom","spruce_door_bottom","purpur_block","purpur_pillar","purpur_pillar_top","end_rod","debug","nether_wart_block","red_nether_bricks","frosted_ice_0","frosted_ice_1","frosted_ice_2","frosted_ice_3" ,
             "beetroots_stage0","beetroots_stage1","beetroots_stage2","beetroots_stage3","debug","debug","debug","debug","debug","debug","debug","debug","debug","debug","debug","debug" ,
             "bone_block_side","bone_block_top","melon_stem","attached_melon_stem","observer_front","observer_side","observer_back","observer_back_on","observer_top","gold_ring","green_ring","structure_block","structure_block_corner","structure_block_data","structure_block_load","structure_block_save" ,
             "black_concrete","blue_concrete","brown_concrete","cyan_concrete","gray_concrete","green_concrete","light_blue_concrete","lime_concrete","magenta_concrete","orange_concrete","pink_concrete","purple_concrete","red_concrete","light_gray_concrete","white_concrete","yellow_concrete" ,
             "black_concrete_powder","blue_concrete_powder","brown_concrete_powder","cyan_concrete_powder","gray_concrete_powder","green_concrete_powder","light_blue_concrete_powder","lime_concrete_powder","magenta_concrete_powder","orange_concrete_powder","pink_concrete_powder","purple_concrete_powder","red_concrete_powder","light_gray_concrete_powder","white_concrete_powder","yellow_concrete_powder" ,
             "black_glazed_terracotta","blue_glazed_terracotta","brown_glazed_terracotta","cyan_glazed_terracotta","gray_glazed_terracotta","green_glazed_terracotta","light_blue_glazed_terracotta","lime_glazed_terracotta","magenta_glazed_terracotta","orange_glazed_terracotta","pink_glazed_terracotta","purple_glazed_terracotta","red_glazed_terracotta","light_gray_glazed_terracotta","white_glazed_terracotta","yellow_glazed_terracotta" ,
             "white_shulker_box","","water_overlay","debug","tube_coral_block","bubble_coral_block","brain_coral_block","fire_coral_block","horn_coral_block","tube_coral","bubble_coral","brain_coral","fire_coral","horn_coral","sea_pickle","blue_ice" ,
             "dried_kelp_top","dried_kelp_side","debug","debug","dead_tube_coral_block","dead_bubble_coral_block","dead_brain_coral_block","dead_fire_coral_block","dead_horn_coral_block","tube_coral_fan","bubble_coral_fan","brain_coral_fan","fire_coral_fan","horn_coral_fan","","" ,
             "debug","debug","debug","debug","debug","debug","debug","debug","debug","dead_tube_coral_fan","dead_bubble_coral_fan","dead_brain_coral_fan","dead_fire_coral_fan","dead_horn_coral_fan","","spruce_trapdoor" ,
             "stripped_oak_log","stripped_oak_log_top","stripped_acacia_log","stripped_acacia_log_top","stripped_birch_log","stripped_birch_log_top","stripped_dark_oak_log","stripped_dark_oak_log_top","stripped_jungle_log","stripped_jungle_log_top","stripped_spruce_log","stripped_spruce_log_top","acacia_trapdoor","birch_trapdoor","dark_oak_trapdoor","jungle_trapdoor" };


        string[] mobs =
        {
             "\\alex","\\alex",
             "\\steve","\\char",
             "\\bat","\\bat",
             "\\chicken","\\chicken",
             "\\dolphin","\\dolphin",
             "\\endermite","\\endermite",
             "\\guardian","\\guardian",
             "\\guardian_beam","\\guardian_beam",
             "\\guardian_elder","\\guardian_elder",
             "\\phantom","\\phantom",
             "\\spider_eyes","\\spider_eyes",
             "\\squid","\\squid",
             "\\steve","\\steve",
             "\\witch","\\witch",
             "\\bear\\polarbear","\\bear\\polarbear",
             "\\creeper\\creeper","\\creeper",
             "\\ghast\\ghast","\\ghast",
             "\\ghast\\ghast_shooting","\\ghast_fire",
             "\\enderdragon\\dragon_fireball","\\enderdragon\\dragon_fireball",
             "\\enderdragon\\dragon","\\enderdragon\\ender",
             "\\end_crystal\\end_crystal_beam","\\enderdragon\\beam",
             "\\enderdragon\\dragon_eyes","\\enderdragon\\ender_eyes",
             "\\enderman\\enderman_eyes","\\enderman\\enderman_eyes",
             "\\enderman\\enderman","\\enderman\\enderman",
             "\\fish\\cod","\\fish\\cod",
             "\\fish\\pufferfish","\\fish\\pufferfish",
             "\\fish\\salmon","\\fish\\salmon",
             "\\fish\\tropical_a","\\fish\\tropical_a",
             "\\fish\\tropical_a_pattern_1","\\fish\\tropical_a_pattern_1",
             "\\fish\\tropical_a_pattern_2","\\fish\\tropical_a_pattern_2",
             "\\fish\\tropical_a_pattern_3","\\fish\\tropical_a_pattern_3",
             "\\fish\\tropical_a_pattern_4","\\fish\\tropical_a_pattern_4",
             "\\fish\\tropical_a_pattern_5","\\fish\\tropical_a_pattern_5",
             "\\fish\\tropical_a_pattern_6","\\fish\\tropical_a_pattern_6",
             "\\fish\\tropical_b","\\fish\\tropical_b",
             "\\fish\\tropical_b_pattern_1","\\fish\\tropical_b_pattern_1",
             "\\fish\\tropical_b_pattern_2","\\fish\\tropical_b_pattern_2",
             "\\fish\\tropical_b_pattern_3","\\fish\\tropical_b_pattern_3",
             "\\fish\\tropical_b_pattern_4","\\fish\\tropical_b_pattern_4",
             "\\fish\\tropical_b_pattern_5","\\fish\\tropical_b_pattern_5",
             "\\fish\\tropical_b_pattern_6","\\fish\\tropical_b_pattern_6",
             "\\horse\\donkey","\\horse\\donkey",
             "\\horse\\horse_black","\\horse\\horse_black",
             "\\horse\\horse_brown","\\horse\\horse_brown",
             "\\horse\\horse_chestnut","\\horse\\horse_chestnut",
             "\\horse\\horse_creamy","\\horse\\horse_creamy",
             "\\horse\\horse_darkbrown","\\horse\\horse_darkbrown",
             "\\horse\\horse_gray","\\horse\\horse_gray",
             "\\horse\\horse_markings_blackdots","\\horse\\horse_markings_blackdots",
             "\\horse\\horse_markings_white","\\horse\\horse_markings_white",
             "\\horse\\horse_markings_whitedots","\\horse\\horse_markings_whitedots",
             "\\horse\\horse_markings_whitefield","\\horse\\horse_markings_whitefield",
             "\\horse\\horse_skeleton","\\horse\\horse_skeleton",
             "\\horse\\horse_white","\\horse\\horse_white",
             "\\horse\\horse_zombie","\\horse\\horse_zombie",
             "\\horse\\mule","\\horse\\mule",
             "\\illager\\evoker","\\illager\\evoker",
             "\\illager\\vex","\\illager\\vex",
             "\\illager\\vex_charging","\\illager\\vex_charging",
             "\\illager\\vindicator","\\illager\\vindicator",
             "\\llama\\spit","\\llama\\spit",
             "\\parrot\\parrot_blue","\\parrot\\parrot_blue",
             "\\parrot\\parrot_green","\\parrot\\parrot_green",
             "\\parrot\\parrot_grey","\\parrot\\parrot_grey",
             "\\parrot\\parrot_red_blue","\\parrot\\parrot_red_blue",
             "\\parrot\\parrot_yellow_blue","\\parrot\\parrot_yellow_blue",
             "\\rabbit\\black","\\rabbit\\black",
             "\\rabbit\\brown","\\rabbit\\brown",
             "\\rabbit\\caerbannog","\\rabbit\\caerbannog",
             "\\rabbit\\gold","\\rabbit\\gold",
             "\\rabbit\\salt","\\rabbit\\salt",
             "\\rabbit\\toast","\\rabbit\\toast",
             "\\rabbit\\white","\\rabbit\\white",
             "\\rabbit\\white_splotched","\\rabbit\\white_splotched",
             "\\shulker\\spark","\\shulker\\spark",
             "\\skeleton\\stray","\\skeleton\\stray",
             "\\skeleton\\skeleton","\\skeleton",
             "\\skeleton\\wither_skeleton","\\skeleton_wither",
             "\\skeleton\\stray_overlay","\\skeleton\\stray_overlay",
             "\\slime\\slime","\\slime",
             "\\villager\\villager","\\villager\\villager",
             "\\wither\\wither","\\wither\\wither",
             "\\wither\\wither_armor","\\wither\\wither_armor",
             "\\wither\\wither_invulnerable","\\wither\\wither_invulnerable",
             "\\zombie\\drowned","\\zombie\\drowned",
             "\\zombie\\husk","\\zombie\\husk",
             "\\zombie_villager\\zombie_villager","\\zombie_villager\\zombie_villager"};



        private void Form1_Load(object sender, EventArgs e)
            {
            foreach(string file in Directory.GetFiles(Environment.CurrentDirectory + "\\block"))
            {
                if (!BlockSheetArray.Contains(Path.GetFileName(file).Split('.')[0]))
                {
                    File.Delete(file);
                }
            }
            foreach(string file in Directory.GetFiles(Environment.CurrentDirectory + "\\item"))
            {
                if (!ItemSheetArray.Contains(Path.GetFileName(file).Split('.')[0]))
                {
                    File.Delete(file);
                }
            }
            foreach(string file in mobs)
            {
                if (File.Exists((Environment.CurrentDirectory + "\\entity" + file + ".png").Replace("/","\\")))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName((Environment.CurrentDirectory + "\\entity2" + file + ".png").Replace("/", "\\")));
                    File.Move((Environment.CurrentDirectory + "\\entity" + file + ".png").Replace("/", "\\"), (Environment.CurrentDirectory + "\\entity2" + file + ".png").Replace("/", "\\"));
                }
            }
        }
    }
}
