using System;
 
public interface ITelewizor {
  int Kanal { get; set; }
  void Wlacz();
  void Wylacz();
  void ZmienKanal(int kanal);
}
 
public class LG : ITelewizor {
  public LG(){
    this.Kanal = 1;
  }
  public int Kanal { get; set; }
 
  public void Wlacz() {
    Console.WriteLine("Telewizor LG - włączam się.");
  }
 
  public void Wylacz() {
    Console.WriteLine("Telewizor LG - wyłączam się.");
  }
 
  public void ZmienKanal(int kanal) {
    Console.WriteLine($"Telewizor LG - zmieniam kanał: {kanal}");
    this.Kanal = kanal;
  }
}
 
public class TvXiaomi : ITelewizor {
  public TvXiaomi(){
    this.Kanal = 1;
  }
  public int Kanal { get; set; }
 
  public void Wlacz() {
    Console.WriteLine("Telewizor Xiaomi - włączam się.");
  }
 
  public void Wylacz() {
    Console.WriteLine("Telewizor Xiaomi - wyłączam się.");
  }
 
  public void ZmienKanal(int kanal) {
    Console.WriteLine($"Telewizor Xiaomi - zmieniam kanał: {kanal}");
    this.Kanal = kanal;
  }
}
 
public abstract class PilotAbstrakcyjny {
  protected ITelewizor tv;
 
  public PilotAbstrakcyjny(ITelewizor tv){
    this.tv = tv;
  }
 
  public void ZmienKanal(int kanal) {
    Console.WriteLine($"Pilot {tv.GetType().Name} - zmienia kanał...");
    tv.ZmienKanal(kanal);
  }
}
 
public class PilotHarmony : PilotAbstrakcyjny {
  public PilotHarmony(ITelewizor tv) : base(tv) { }
 
  public void DoWlacz(){
    Console.WriteLine("Pilot Harmony - włącz telewizor...");
    tv.Wlacz();
  }
 
  public void DoWylacz(){
    Console.WriteLine("Pilot Harmony - wyłącz telewizor...");
    tv.Wylacz();
  }
}
 
public class PilotLG : PilotAbstrakcyjny {
  public PilotLG(ITelewizor tv) : base(tv) { }
 
  public void DoWylacz(){
    Console.WriteLine("Pilot Philips - wyłącz telewizor...");
    tv.Wylacz();
  }
}
 
class MainClass {
  public static void Main (string[] args) {
    ITelewizor tv = new LG();
    PilotHarmony pilotHarmony = new PilotHarmony(tv);
    PilotLG PilotLG = new PilotLG(tv);
 
    pilotHarmony.DoWlacz();
    Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
    PilotLG.ZmienKanal(100);
    Console.WriteLine("Sprawdź kanał - bieżący kanał: " + tv.Kanal);
    pilotHarmony.DoWylacz();
  }
}
