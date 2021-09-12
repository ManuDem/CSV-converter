using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\manud\Documents\GitHub\CSV-converter\pokemon.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    for (int count = 0; count < fields.Length; count++)
                    {
                        int pokedex_number = 0;
                        string name = "ERROR";
                        int hp = 0;
                        int attack = 0;
                        int defense = 0;
                        int spAttack = 0;
                        int spDefense = 0;
                        int speed = 0;
                        int expYeld = 0;
                        int catchRate = 0;

                        try
                        {
                            pokedex_number = Int32.Parse(fields[0]);
                            name = fields[1];
                            hp = Int32.Parse(fields[5]);
                             attack = Int32.Parse(fields[6]);
                             defense = Int32.Parse(fields[7]);
                             spAttack = Int32.Parse(fields[8]);
                             spDefense = Int32.Parse(fields[9]);
                             speed = Int32.Parse(fields[10]);
                             expYeld = Int32.Parse(fields[13]);
                             catchRate = Int32.Parse(fields[13]);
                        }
                        catch
                        {
                        }

                        string path = @"C:\\Users\manud\Desktop\Test\" + $"{pokedex_number:D3}" + " " + name + ".asset";

                        if (!File.Exists(path))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine("%YAML 1.1");
                                sw.WriteLine("%TAG !u! tag:unity3d.com,2011:");
                                sw.WriteLine("--- !u!114 &11400000");
                                sw.WriteLine("MonoBehaviour:");
                                sw.WriteLine("  m_ObjectHideFlags: 0");
                                sw.WriteLine("  m_CorrespondingSourceObject: {fileID: 0}");
                                sw.WriteLine("  m_PrefabInstance: {fileID: 0}");
                                sw.WriteLine("  m_PrefabAsset: {fileID: 0}");
                                sw.WriteLine("  m_GameObject: {fileID: 0}");
                                sw.WriteLine("  m_Enabled: 1");
                                sw.WriteLine("  m_EditorHideFlags: 0");
                                sw.WriteLine("  m_Script: {fileID: 11500000, guid: e5aa4a7f37a22714c9924381e9ade610, type: 3}");
                                sw.WriteLine("  m_Name: " + $"{pokedex_number:D3}");
                                sw.WriteLine("  m_EditorClassIdentifier: ");
                                sw.WriteLine("  name: " + name);
                                sw.WriteLine("  description: ");
                                sw.WriteLine("  frontSprite: ");
                                sw.WriteLine("  backSprite: ");
                                sw.WriteLine("  type1: 0");
                                sw.WriteLine("  type2: 0");
                                sw.WriteLine("  maxHp: " + hp);
                                sw.WriteLine("  attack: " + attack);
                                sw.WriteLine("  defense: " + defense);
                                sw.WriteLine("  spAttack: " + spAttack);
                                sw.WriteLine("  spDefense: " + spDefense);
                                sw.WriteLine("  speed: " + speed);
                                sw.WriteLine("  expYield: " + expYeld);
                                sw.WriteLine("  growthRate: 0");
                                sw.WriteLine("  catchRate: " + catchRate);
                            }
                        }
                    }
                }
            }

            /* int pokedex_number = 4;
             string name = "Charmander";
             int hp = 39;
             int attack = 52;
             int defense = 43;
             int sp_attack = 60;
             int sp_defense = 50;
             int speed = 65;
             int exp_yeld = 62;
             int capture_rate = 45;

             string path = @"C:\\Users\manud\Desktop\Test" + $"{pokedex_number:D3}" + " "+ name + ".asset";

             if (!File.Exists(path))
             {
                 // Create a file to write to.
                 using (StreamWriter sw = File.CreateText(path))
                 {
                     sw.WriteLine("%YAML 1.1");
                     sw.WriteLine("%TAG !u! tag:unity3d.com,2011:");
                     sw.WriteLine("--- !u!114 &11400000");
                     sw.WriteLine("MonoBehaviour:");
                     sw.WriteLine("  m_ObjectHideFlags: 0");
                     sw.WriteLine("  m_CorrespondingSourceObject: {fileID: 0}");
                     sw.WriteLine("  m_PrefabInstance: {fileID: 0}");
                     sw.WriteLine("  m_PrefabAsset: {fileID: 0}");
                     sw.WriteLine("  m_GameObject: {fileID: 0}");
                     sw.WriteLine("  m_Enabled: 1");
                     sw.WriteLine("  m_EditorHideFlags: 0");
                     sw.WriteLine("  m_Script: {fileID: 11500000, guid: e5aa4a7f37a22714c9924381e9ade610, type: 3}");
                     sw.WriteLine("  m_Name: "+ $"{pokedex_number:D3}");
                     sw.WriteLine("  m_EditorClassIdentifier: ");
                     sw.WriteLine("  name: " + pokemon_name);
                     sw.WriteLine("  description: ");
                     sw.WriteLine("  frontSprite: ");
                     sw.WriteLine("  backSprite: ");
                     sw.WriteLine("  type1: 0");
                     sw.WriteLine("  type2: 0");
                     sw.WriteLine("  maxHp: "+ hp);
                     sw.WriteLine("  attack: " + attack);
                     sw.WriteLine("  defense: " + defense);
                     sw.WriteLine("  spAttack: " + sp_attack);
                     sw.WriteLine("  spDefense: " + sp_defense);
                     sw.WriteLine("  speed: "  + speed);
                     sw.WriteLine("  expYield: " + exp_yeld);
                     sw.WriteLine("  growthRate: 0");
                     sw.WriteLine("  catchRate: " + name);
                 }
             }*/
        }
    }
}