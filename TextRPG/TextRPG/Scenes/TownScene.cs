namespace TextRPG;

public class TownScene : Scene
{
    public override void Render()
    {
        Game.PrintInfo();
        Util.Print("사람들이 북적거리는 마을이다...", ConsoleColor.White, 1000);
        Util.Print("여러 상인들이 물건을 팔고 있다..", ConsoleColor.White, 1000);
        Util.Print("멀리서 수상한 남성이 눈치를 보고있다", ConsoleColor.Red, 1000);
        Console.WriteLine();
    }

    public override void Choice()
    {
        Console.WriteLine("1. 상인에게 간다");
        Console.WriteLine("2. [속도] 멀리서 수상한 남성을 주시한다.");
        Console.WriteLine("3. 일단 파밍이지, 필드로 나간다.");
    }

    public override void Result()
    {
        switch (input)
        {
            case ConsoleKey.D1:
                Util.Print("상인에게 접근합니다", ConsoleColor.White, 1000);
                // Console.WriteLine("상인에게 접근합니다");
                break;
            case ConsoleKey.D2:
                Console.WriteLine("당신은 수상한 남성을 주시하고 있었습니다");
                Console.WriteLine("수상한 남성이 당신의 눈빛을 눈치챘습니다.");
                Console.WriteLine("날카로운 단검을 당신에게 던졌고,");
                if (Game.Player.Speed >= 10)
                {
                    Console.WriteLine("당신은 단검을 재빠르게 피했습니다.");
                    Console.WriteLine("수상한 남자는 당황하며 도망가기 시작합니다..");
                    Console.WriteLine("당신은 수상한 남자를 쫒아갑니다");
                }
                else
                {
                    Console.WriteLine("당신은 단검을 피하기에 충분히 빠르지 못했습니다.");
                    Console.WriteLine("당신은 그것을 미쳐 피하지 못했습니다.");
                }
                // Util.Print("당신은 수상한 남성을 주시하고 있었습니다", ConsoleColor.White, 1000);
                // Util.Print("수상한 남성이 당신의 눈빛을 눈치챘습니다.", ConsoleColor.Red, 1000);
                // Util.Print("날카로운 단검을 당신에게 던졌고", ConsoleColor.White, 1000);
                // Util.Print("당신은 그것을 미쳐 피하지 못했습니다", ConsoleColor.White, 1000);
                break;
            case ConsoleKey.D3:
                Console.WriteLine("필드로 나간다");
                break;
            default:
                Console.WriteLine("잘 못 입력했습니다.");
                break;
        }
    }

    public override void Wait()
    {
        Console.WriteLine("계속하려면 아무키나 눌러주세요..");
        Console.ReadKey();
    }

    public override void Next()
    {
        switch (input)
        {
            case ConsoleKey.D1:
                Game.ChangeScene("Shop");
                break;
            case ConsoleKey.D2:
                if (Game.Player.Speed >= 10)
                {
                    // TODO: 추격 씬 전환
                    Console.WriteLine("추격씬");
                }
                else
                {
                    Game.GameOver("수상한 사람은 함부로 쫒지 않도록 합시다...");
                }
                break;
        }
    }
}