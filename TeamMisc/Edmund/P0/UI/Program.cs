using Models;
using UI;
using DL;
using BL;


IRepo repo = new FileRepo();
SBL bl = new SBL(repo);
MainMenu menu = new MainMenu(bl);
menu.Start();