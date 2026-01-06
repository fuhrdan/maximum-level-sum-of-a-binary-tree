//*****************************************************************************
//** 1161. Maximum Level Sum of a Binary Tree                       leetcode **
//*****************************************************************************
//** Traversing levels where each branch resides,                            **
//** Running sums to find where the maximum hides.                           **
//** Each layer is checked with a queue in clear view,                       **
//** Ending on the level where the total rings true.                         **
//*****************************************************************************

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
int maxLevelSum(struct TreeNode* root) {
    if (root == NULL)
    {
        return 0;
    }

    struct TreeNode* queue[10000];
    int head = 0;
    int tail = 0;

    queue[tail++] = root;

    int currLevel = 1;
    int maxLevel = 1;
    int maxSum = INT_MIN;

    while (head < tail)
    {
        int levelSize = tail - head;
        int levelSum = 0;

        for (int i = 0; i < levelSize; i++)
        {
            struct TreeNode* node = queue[head++];
            levelSum += node->val;

            if (node->left != NULL)
            {
                queue[tail++] = node->left;
            }

            if (node->right != NULL)
            {
                queue[tail++] = node->right;
            }
        }

        if (levelSum > maxSum)
        {
            maxSum = levelSum;
            maxLevel = currLevel;
        }

        currLevel++;
    }

    return maxLevel;
}