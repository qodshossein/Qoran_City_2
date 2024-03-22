// Copyright (C) 2015-2023 ricimi - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;
using UnityEngine.UI;

namespace Ricimi
{
    // Utility class for swapping the sprite of a UI Image between two predefined values.
    public class SpriteSwapper : MonoBehaviour
    {
        public Sprite enabledSprite;
        public Sprite disabledSprite;
        [SerializeField] private Image m_image;

        private bool m_swapped = true;


        public void Awake()
        {
            if (!m_image)
                m_image = GetComponent<Image>();
        }

        public void SwapSprite()
        {
            if (m_swapped)
            {
                m_swapped = false;
                m_image.sprite = disabledSprite;
            }
            else
            {
                m_swapped = true;
                m_image.sprite = enabledSprite;
            }
        }
    }
}
