﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsar4X;
using Pulsar4X.UI;
using Pulsar4X.UI.GLUtilities;
using OpenTK;
using Pulsar4X.Entities;

namespace Pulsar4X.UI.SceenGraph
{
    /// <summary>
    /// A Planet node/element in a sceen graph.
    /// </summary>
    class PlanetElement : SceenElement
    {

        private Planet m_oPlanet;


        public override GameEntity SceenEntity
        {
            get
            {
                return m_oPlanet;
            }
            set
            {
                m_oPlanet = value as Planet;
            }
        }

        /// <summary>
        /// This is the display element for the orbit this planet will make.
        /// </summary>
        private CircleElement m_oOrbitCircle { get; set; }


        public PlanetElement()
            : base()
        {
        }

        public PlanetElement(GLEffect a_oDefaultEffect, Vector3 a_oPosition, Planet a_oPlanet,  System.Drawing.Color a_oColor)
            : base(a_oPlanet)
        {
            m_oOrbitCircle = new CircleElement(a_oDefaultEffect, a_oPosition, a_oPlanet, a_oColor);
#warning Cannot add m_oOrbitCircle to children for Planet Element
        }


        public override void Render()
        {
            foreach (GLPrimitive oPrimitive in m_lPrimitives)
            {
                oPrimitive.Render();
            }

            /// <summary>
            /// Putting this as a child means that it runs afoul of the "don't render children" check.
            /// </summary>
            m_oOrbitCircle.Render();

            if (RenderChildren == true)
            {
                foreach (SceenElement oElement in m_lChildren)
                {
                    oElement.Render();
                }
            }

            if (m_oLable != null)
            {
                m_oLable.Render();
            }
        }


        public override Guid GetSelected(Vector3 a_v3AtPos)
        {
            Guid oElementID = Guid.Empty;

            // check To see if position provided is close to our primary primitive:
            float fDist = (m_oPrimaryPrimitive.Position - a_v3AtPos).Length;
            if (m_oPrimaryPrimitive.Size.X > fDist)
            {
                // then we are selecting this object!!
                return this.EntityID;
            }

            // else go though this elements children.
            foreach (SceenElement oElement in m_lChildren)
            {
                oElementID = oElement.GetSelected(a_v3AtPos);

                if (oElementID != Guid.Empty)
                {
                    // we have found something, retur its ID:
                    return oElementID;
                }
            }

            return Guid.Empty;
        }


        public override void Refresh(float a_fZoomScaler)
        {
            // Adjust the size of the Primary Sprite (the planet icon) if necessary.
            if (MinimumSize.X > 0 && MinimumSize.Y > 0)
            {
                // calc size in pixels given current zoom factor:
                Vector2 v2CurrSize = RealSize * a_fZoomScaler;

                if (MinimumSize.X > v2CurrSize.X && MinimumSize.Y > v2CurrSize.Y)
                {
                    // then it is too small, make it display at a proper size: 
                    PrimaryPrimitive.SetSize(MinimumSize / a_fZoomScaler);

                    // turn off moons if min orbit < icon size in world coords:
                    float test = (MinimumSize.X / a_fZoomScaler);
                    if (SmallestOrbit < test)
                    {
                        // we are overlapping, weill not draw children:
                        RenderChildren = false;
                    }
                    else
                    {
                        // we are not overlapping, will draw children:
                        RenderChildren = true;
                    }
                }
                else
                {
                    // we want to draw to scale:
                    PrimaryPrimitive.SetSize(RealSize);

                    // turn off moons if min orbit < icon size in world coords:
                    float test = (RealSize.X / a_fZoomScaler);
                    if (SmallestOrbit < test)
                    {
                        // we are overlapping, weill not draw children:
                        RenderChildren = false;
                    }
                    else
                    {
                        // we are not overlapping, will draw children:
                        RenderChildren = true;
                    }
                }
            }

            // Adjust the size of the text so it is always 10 point:
            Lable.Size = UIConstants.DEFAULT_TEXT_SIZE / a_fZoomScaler; 

            /// <summary>
            /// Update the position of this element.
            /// </summary>
            Vector3 pos = new Vector3((float)(m_oPlanet.XSystem), (float)(m_oPlanet.YSystem), 0.0f);

            PrimaryPrimitive.Position = pos;
            Lable.Position = pos;

            Vector3 pos2 = new Vector3((float)m_oPlanet.Parent.XSystem, (float)m_oPlanet.Parent.YSystem, 0.0f);
            m_oOrbitCircle.CurrentPosition = pos2;

            /// <summary>
            /// Putting this as a child means that it runs afoul of the "don't render children" check.
            /// </summary>
            m_oOrbitCircle.Refresh(a_fZoomScaler);

            // loop through any children:
            foreach (SceenElement oElement in m_lChildren)
            {
                oElement.Refresh(a_fZoomScaler);
            }
        }
    }
}
