using UnityEngine;

/// <summary>
/// Extention methods for the Unity Sprite class
/// </summary>

public static class SpriteExtensions
{

    public static float GetAlpha(this SpriteRenderer sprite)
    {
        return sprite.color.a;
    }

    public static void SetAlpha(this SpriteRenderer sprite, float alpha)
    {
        var color = sprite.color;
        color.a = Mathf.Clamp(alpha, 0f, 1f);
        sprite.color = color;
    }

}
