#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main() 
{
	string str1, str2;
	cin >> str1 >> str2;
		int m = str1.length(), n= str2.length(),k;
	vector<int> res(m+1);
	vector<vector<int>> way(m+1);
	res[0] = 0;	
	for (int i = 1; i < m+1; i++) {
		res[i] = 0;
		way[i]=way[i-1];
		way[i].push_back(1);
	}
	for (int i = 1; i < n+1; i++) {						
		for (int j = m; j > 0; j--) {
			if (str2[i-1] == str1[j-1])
				k = 1;
			else k = 0;
			if (res[j] < res[j - 1] + k)
			{
				res[j] = res[j - 1] + k;
				way[j] = way[j - 1];
				way[j].push_back(3);
			}
			else way[j].push_back(2);
		}

		res[0] = 0;
		way[0].push_back(2);				

		for (int j = 1; j < m+1; j++)
		{
			if (res[j] < res[j - 1])
			{
				res[j] = res[j - 1];
				way[j] = way[j - 1];
				way[j].push_back(1);
			}
		}
	}
	string rs="";
	int p = 0;
	for (int i = 0; i < way[m].size()-1; i++)
		switch (way[m][i]) 
		{
			case 1:p++; break;		
			case 2:break;
			case 3:rs += str1[p]; p++; break;
		}
	cout<< rs <<endl;
	return 0;
}