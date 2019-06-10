#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main() 
{
	vector<string> str;
	string temp, res;
	while (!cin.eof())
	{		
		getline(cin, temp);
        str.push_back(temp);
	}
    for (int i = 0; i < str.size(); i++)
	{
		if (i == 0)
			res += str[i];
		else
		{
			temp = str[i];
			res += temp[temp.length() - 1];
		}
    }
	cout << res;
	return 0;
}