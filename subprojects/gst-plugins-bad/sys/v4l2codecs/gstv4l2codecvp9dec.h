
/* GStreamer
 * Copyright (C) 2021 Daniel Almeida <daniel.almeida@collabora.com>
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public
 * License as published by the Free Software Foundation; either
 * version 2 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Library General Public License for more details.
 *
 * You should have received a copy of the GNU Library General Public
 * License along with this library; if not, write to the
 * Free Software Foundation, Inc., 51 Franklin St, Fifth Floor,
 * Boston, MA 02110-1301, USA.
 */

#pragma once

#include "gstv4l2decoder.h"

G_BEGIN_DECLS

void  gst_v4l2_codec_vp9_dec_register (GstPlugin * plugin,
                                       GstV4l2Decoder * decoder,
                                       GstV4l2CodecDevice * device,
                                       guint rank);

G_END_DECLS
