using System.ComponentModel;
using System.Runtime.Serialization;

class SupportTikcet {
    
    public string IssueType{ get; set; }
    public string Description{ get; set; }

    public SupportTikcet(string issueType, string description){
        this.IssueType = issueType;
        this.Description = description;
    }

}

abstract class SupportHandler {

    protected SupportHandler? _next;
    public SupportHandler SetNext(SupportHandler next) { 
        
        this._next =  next;

        return this;
    }

    public void Handle(SupportTikcet ticket) {

        if (CanHandle(ticket)) {
            Process(ticket);
        }
        
        else if (_next != null) {
            _next.Handle(ticket);
        }

        else {
            throw new Exception("No handler could process the ticket.");
        }

    }

    public abstract bool CanHandle(SupportTikcet tikcet);

    public abstract void Process(SupportTikcet ticket);

}

class BillingSupport : SupportHandler {

    public override bool CanHandle(SupportTikcet tikcet)
    {

        if (string.Compare(tikcet.IssueType,"billing",true) == 0) {
            return true;
        }
        return false;
    }

    public override void Process(SupportTikcet ticket)
    {
            Console.WriteLine($" ✅{ticket.IssueType} Support handled the issue: {ticket.Description}");
        
    }

}

class TechnicalSupport : SupportHandler {

    public override bool CanHandle(SupportTikcet tikcet)
    {

        if (string.Compare(tikcet.IssueType,"technical",true) == 0) {
            return true;
        }
        return false;
    }

    public override void Process(SupportTikcet ticket)
    {
            Console.WriteLine($" ✅{ticket.IssueType} Support handled the issue: {ticket.Description}");

        
    }

}

class GeneralSupport : SupportHandler {

    public override bool CanHandle(SupportTikcet tikcet)
    {
            return true;
        
    }

    public override void Process(SupportTikcet ticket)
    {
        if (CanHandle(ticket)) {
            Console.WriteLine($" ✅GeneralSupport handled the issue: {ticket.Description}");
        }

      
    }

}