﻿               using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();

			var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = "    <h1>Aboot</h1>\n    <p>\n        A boot, a shoe? I don't get it. How is this funny? Huh?! My Canadian humour is a work in progress, much like this app.\n    " +
                "</p>\n    <p>\n        It was at a rowdy Phat Wednesday apres last summer that the idea for it came to me. The weekly scrum to get a copy of the\n        " +
                "results printout was in need of an upgrade. We're not talkin' laminating those printouts, that would be silly. Nah, we're\n        " +
                "taking this bad boy into the future, 2.0 style. Insert Crazy German: Whistler-enamored/bike fanatic/programming beast.\n    </p>\n    <p>\n        " +
                "I came to Whistler a few years ago in search of Whistler. Found it. I wanna call it home; working on it. I wanna give back;\n        " +
                "working on that too (hint: <em>it's through this app!</em>).\n    </p>\n    <p>\n        " +
                "<em>Spokesman</em> has been a labour of love and as you can see it's still in its very early stages. It's kind of like\n        " +
                "a Kinderapp at this point. I've got more ideas and concepts than you can shake a stick at (in German we say <em>\"my ideas are in the butter\"</em>)\n       " +
                " and I'm super pumped to get it out there in the hopes that there are other grateful riders in this beauty of a town that\n        " +
                "are as stoked as I am to give back to our one-of-a-kind biking community. Call it a community passion project, and the\n        " +
                "more people that get involved, the better. Posting Phat Wednesday race results is just the beginning. Have ideas? Knowledge?\n        " +
                "Time? Money? Spot a bug? I wanna hear from you! Let's DO this! And let's\n        " +
                "do this in a way that it'll always free 'cause bringing like-minded people together shouldn't cost a thing!\n    " +
                "</p>\n    <h1>Danke\n      <small> (German for thank you, <em>not</em> 'donkey')</small>\n    </h1>\n    <p>\n        " +
                "There are some key contributors that in this infancy stage of <em>Spokesman</em> need thanking. Mountains of thanks to\n        " +
                "the Whistler Blackcomb Events team,\n        especially Colleen Ikona, for taking the time to listen to my thick\n        " +
                "German accent and for uploading the official race results. Without WB's data\n        " +
                "<em>Spokesman</em> would be kaput. Danke Greg West from for setting up the server, props! Thank you to Jack Crompton from Ridebooker for his love of great ideas and his flexibility and\n        " +
                "willingness to let me pursue them. And thank you to my girlfriend for her unending support; Kate is great!\n    </p>";
            
            webView.Source = htmlSource;

        }
    }
}
