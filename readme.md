[ASSIGNMENT] Senior Software Developer

The business has a requirement to build a web portal that would provide its clients with trending, gainers, losers, volume, new and hotlist Crypto coins. The portal should provide basic information about these coins and allow the clients to view these coins in two different market insight providers.

[Story] [ Estimation expected ] [5] [Initial setup risks to spend more time]

Given I have a list of categories, when I click on each category, then I expect to see the relevant coins displayed from primary and secondary providers with their price and price change.

[Story] [ Estimation expected ] [3]

Given I am viewing the categorized coins returned by primary & secondary market insight providers with price and price change within past 24 hours, when I click on any of the provider’s price, then I expect to see the basic information about the coin such as price, change rate, market cap and price difference between the providers retrieved from respective provider.

[Story] [ Estimation expected ] [2]

Given I am viewing the categorized coins returned by the primary & secondary market Insight providers, when the symbol returned by primary market insight provider is not found at secondary market insight provider, then I expect to see N/A and it should not be clickable.

[Story] [ Estimation expected ] [1]

Given I am landed on a page that provides me the basic information of the coin, when I choose to go back to the overview page, then I should have a back button to do so.

APIs:

Primary Market Insight Provider ( KuCOIN ) :

Categories: GET <https://www.kucoin.com/_api/discover-front/spl/list?lang=en_US&typeList=HOME_LIST%2CLIST>

Coin information: GET <https://www.kucoin.com/_api/discover-front/spl?lang=en_US&tagId=[:id>]

                The :id is returned from Categories API

Individual coin information: <https://www.kucoin.com/_api/quicksilver/universe-currency/symbols/stats/BNB-USDT?lang=en_US>

Secondary (Gate.io)

List of coins: POST <https://www.gate.io/market_price/get_coin_list>

Individual coin info: POST <https://www.gate.io/apiwap/getCoinInfo>

Payload: form-data -> Key = curr_type & value = [symbol], symbol is returned by the primary provider
