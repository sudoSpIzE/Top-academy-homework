[HttpGet]
public string Time()
{
    return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
}
