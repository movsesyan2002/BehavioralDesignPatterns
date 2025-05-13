// you are developing a flexible, event-driven news broadcasting platform where users can subscribe to specific news categories such as Politics, Sports, or Tech. Your system will use C#'s event and delegate mechanisms to notify subscribers, but with a twist:
// Categories are defined using an enum

// Each category acts as an independent event channel

// Subscribers can subscribe/unsubscribe to any number of categories

// Publishing a news headline in a category triggers only the relevant subscribers

// This exercise simulates real-world streaming platforms and advanced pub-sub (publish-subscribe) architectures.

// 🧱 Structure Overview
// 🔹 Enum: NewsCategory

// public enum NewsCategory
// {
//     Politics,
//     Sports,
//     Tech
// }

// 🔹 NewsAgency (Publisher)

// Maintains a dictionary: Dictionary<NewsCategory, event Action<string>>

// Methods:

// Subscribe(NewsCategory category, Action<string> handler)

// Unsubscribe(NewsCategory category, Action<string> handler)

// Publish(NewsCategory category, string headline)

// 🔹 Subscriber
// Has a Name

// Method: Receive(string headline) (will be adapted per category)

// Subscribes/unsubscribes to specific NewsCategory events

// Explain me this in Armenian preserving English and C# terms


public enum NewsCategory{
    Politics,
    Sports,
    Tech
}

class NewsAgency {

    Dictionary<NewsCategory, Action<string>> keyValuePairs= new Dictionary<NewsCategory,Action<string>>();

    public void Subscribe(NewsCategory category, Action<string> action) {

        if (keyValuePairs.ContainsKey(category)) {
            keyValuePairs[category] += action;
            return;
        }

        keyValuePairs[category] = action;

    }

    public void Unsubscribe(NewsCategory category, Action<string> action) {
        if (keyValuePairs.ContainsKey(category)) {
            keyValuePairs[category] -= action;
        }

        else {
            Console.WriteLine("No events");
        }

    }
    

    public void Publish (NewsCategory category, string headline) {
        if (keyValuePairs.ContainsKey(category)) {
            keyValuePairs[category].Invoke(headline);
        }
    }
}


interface ISubscriber {

    void ReceiveTech(string headline);
    void ReceiveSports(string headline);
    void ReceivePolitics(string headline);
}


class Subscriber : ISubscriber {

    public string? Name { get; set; }

    public Subscriber (string? name) {
        Name = name;
    }

    public void ReceiveTech(string headline) {
        Console.WriteLine($"[{Name}] [{NewsCategory.Tech.ToString()}][{headline}]");
    }

    public void ReceiveSports(string headline) {
        Console.WriteLine($"[{Name}]  [{NewsCategory.Sports.ToString()}] [{headline}]");
    }
    
    public void ReceivePolitics(string headline) {
        Console.WriteLine($"[{Name}] [{NewsCategory.Politics.ToString()}] [{headline}]");
    }


}