using System.Threading.Tasks;
namespace Async;

public class Test
{
    public Test()
    {
        CookCream();
        CookCreamAsync();
    }
    private void CookCream()
    {
        WriteLine("Cook Cream");
        PrepareIngredients();
        StirYolk();
        WriteLine("Cream done");
    }
    private async void CookCreamAsync()
    {
        var ingr = PrepareIngredientsAsync();
        var yolk = StirYolkAsync();
        await ingr;
        await yolk;
        WriteLine("Cream done");
    }
    private async void PrepareIngredients()
    {
        Task.Delay(1000).Wait();
        WriteLine("Sugar 1 cup");
        WriteLine("4 yolk");
        WriteLine("Lemon juice 1/4 tablespoon");
        return;
    }
    private bool StirYolk()
    {
        Task.Delay(1000).Wait();
        WriteLine("Stir yolk have done");
        return true;
    }
    private async Task PrepareIngredientsAsync()
    {
        await Task.Delay(1000);
        WriteLine("Sugar 1 cup");
        WriteLine("4 yolk");
        WriteLine("Lemon juice 1/4 tablespoon");
        return;
    }
    private async Task StirYolkAsync()
    {
        await Task.Delay(1000);
        WriteLine("Stir yolk have done");
        return;
    }
}

