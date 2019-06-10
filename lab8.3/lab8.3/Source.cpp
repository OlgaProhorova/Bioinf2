#include <string>
#include <vector>
#include <iostream>

using namespace std;

int main()
{
	vector<string> str,res;
	string temp;
	while (!cin.eof())
	{
		cin >> temp;
		str.push_back(temp);
	}
	int k = str[0].length();
	for (int i = 0; i < str.size(); i++)
	{
		for (int j = 0; j < str.size(); j++)
		{
			if (i != j)
			{
				if (str[i].substr(1,k-1) == str[j].substr(0,k-1))
				{
					res.push_back(str[i]);
					res.push_back(str[j]);
				}
			}
		}
	}
	for (int i = 0; i < res.size() - 1; i+=2)
	{
		cout << res[i] << " -> " << res[i + 1] << endl;
	}
	return 0;
}