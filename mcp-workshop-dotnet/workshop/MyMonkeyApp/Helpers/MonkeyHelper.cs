using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// 원숭이 데이터 관리를 위한 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// 모든 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        // MCP 서버에서 데이터 가져오기 (예시: 실제 구현 필요)
        monkeys = await FetchMonkeysFromMcpServerAsync();
        return monkeys;
    }

    /// <summary>
    /// 랜덤 원숭이 한 마리를 반환하고, 접근 횟수를 증가시킵니다.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var allMonkeys = await GetMonkeysAsync();
        if (allMonkeys.Count == 0)
            return null;
        randomMonkeyAccessCount++;
        var random = new Random();
        return allMonkeys[random.Next(allMonkeys.Count)];
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var allMonkeys = await GetMonkeysAsync();
        return allMonkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이 접근 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 가져오는 메서드 (실제 MCP 연동 필요)
    /// </summary>
    private static async Task<List<Monkey>> FetchMonkeysFromMcpServerAsync()
    {
        // TODO: MCP 서버에서 데이터를 가져오는 실제 구현 필요
        // 아래는 예시 데이터
        await Task.Delay(100); // 비동기 예시
        return new List<Monkey>
        {
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Population = 10000, Latitude = -8.783195, Longitude = 34.508523 },
            new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Population = 23000, Latitude = 12.769013, Longitude = -85.602364 },
            // ... 나머지 원숭이 데이터 추가 ...
        };
    }
}
