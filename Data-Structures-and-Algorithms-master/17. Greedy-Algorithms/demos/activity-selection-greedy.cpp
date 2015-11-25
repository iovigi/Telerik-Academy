#include<iostream>
#include<vector>
#include<algorithm>

using namespace std;

struct Activity
{
    int s;
    int f;

    Activity(int s = 0, int f = 0)
    {
        this->s = s;
        this->f = f;
    }

    bool operator < (const Activity& other) const
    {
        return this->f < other.f;
    }

    bool IsCompatible(const Activity& other)
    {
        bool intersect = (this->s <= other.s && this->f >= other.s) ||
                         (this->s <= other.f && this->f >= other.f) ||
                         (this->s >= other.s && this->f <= other.f) ||
                         (this->s <= other.s && this->f >= other.f);

        return !intersect;
    }
};

int main()
{
    int numActivities;
    cin>>numActivities;

    vector<Activity> activities;
    for(int i=0; i<numActivities; i++)
    {
        int s, f;
        cin>>s>>f;
        activities.push_back(Activity(s, f));
    }

    sort(activities.begin(), activities.end());

    vector<int> selectedIndices;

    selectedIndices.push_back(0);
    Activity lastSelected = activities[0];
    for(int i=1; i < activities.size(); i++)
    {
        if(lastSelected.IsCompatible(activities[i]))
        {
            selectedIndices.push_back(i);
            lastSelected = activities[i];
        }
    }

    cout<<selectedIndices.size()<<endl;

    for(int i=0; i<selectedIndices.size(); i++)
    {
        cout<<selectedIndices[i]<<endl;
    }
}
/*
11
1	4
3	5
0	6
5	7
3	8
5	9
6	10
8	11
8	12
2	13
12	14
*/
