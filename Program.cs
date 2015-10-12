﻿using System;
using Starcounter;

namespace KitchenSink
{
  class Program
  {
    static void Main()
    {
      Handle.GET("/KitchenSink/standalone", () => {
        Session session = Session.Current;

        if (session != null && session.Data != null)
          return session.Data;

        var standalone = new StandalonePage();

        if (session == null)
        {
          session = new Session(SessionOptions.PatchVersioning);
          standalone.Html = "/KitchenSink/StandalonePage.html";
        }

        var nav = new NavPage();
        standalone.CurrentPage = nav;

        standalone.Session = session;
        return standalone;
      });

      Handle.GET("/KitchenSink", () => {
        return Self.GET("/KitchenSink/text");
      });

      Handle.GET("/KitchenSink/button", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is ButtonPage)) {
          var page = new ButtonPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/checkbox", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is CheckboxPage)) {
          var page = new CheckboxPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/dropdown", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is DropdownPage)) {
          var page = new DropdownPage();

          DropdownPage.PetsElementJson pet;
          pet = page.Pets.Add();
          pet.Label = "dogs";

          pet = page.Pets.Add();
          pet.Label = "cats";

          pet = page.Pets.Add();
          pet.Label = "rabbit";

          page.SelectedPet = "dogs";

          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/html", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is HtmlPage)) {
          var page = new HtmlPage();
          page.Bio = @"<h1>This is a markup text</h1>

You can put <strong>any</strong> <a href=""https://en.wikipedia.org/wiki/HTML"">HTML</a> in it.";
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/integer", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is IntegerPage)) {
          var page = new IntegerPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/markdown", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is MarkdownPage)) {
          var page = new MarkdownPage();
          page.Bio = @"# This is a strucured text

It supports **markdown** *syntax*.";
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/multiselect", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is MultiselectPage)) {
          var page = new MultiselectPage();
          MenuOptionsElement a;
          a = page.MenuOptions.Add();
          a.Label = "Dogs";
          a = page.MenuOptions.Add();
          a.Label = "Cats";
          page.SelectOption(0);
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/password", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is PasswordPage)) {
          var page = new PasswordPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/text", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is TextPage)) {
          var page = new TextPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/textarea", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is TextareaPage)) {
          var page = new TextareaPage();
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/radio", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is RadioPage)) {
          var page = new RadioPage();

          RadioPage.PetsElementJson pet;
          pet = page.Pets.Add();
          pet.Label = "dogs";

          pet = page.Pets.Add();
          pet.Label = "cats";

          pet = page.Pets.Add();
          pet.Label = "rabbit";

          page.SelectedPet = "dogs";

          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });

      Handle.GET("/KitchenSink/url", () => {
        var master = (StandalonePage)Self.GET("/KitchenSink/standalone");
        if (!((master.CurrentPage as NavPage).CurrentPage is UrlPage)) {
          var page = new UrlPage();
          page.Url = "/KitchenSink";
          page.Label = "Go to home page";
          (master.CurrentPage as NavPage).CurrentPage = page;
        }
        return master;
      });
    }
  }
}